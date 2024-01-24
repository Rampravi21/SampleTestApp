using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using RoomReservationApp.Models;
using Microsoft.AspNetCore.Identity;
using RoomReservationApp.Data;

namespace RoomReservationApp.Controllers
{

    [Authorize]
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReservationController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }



        public IActionResult Index()
        {
            var reservations = _context.Reservations.Include(r => r.Room).ToList();
            return View(reservations);
        }

        [HttpGet]
        public IActionResult Reserve(int roomId)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.Id == roomId);

            if (room == null)
            {
                return NotFound();
            }

            var reservationDetails = new ReservationDetailsViewModel
            {
                RoomId = room.Id,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1)
            };

            return View(reservationDetails);
        }


        [HttpPost]
        public async Task<IActionResult> Reserve(ReservationDetailsViewModel reservationDetails)
        {
            if (ModelState.IsValid)
            {
                // Validate reservation logic (check for overlapping appointments)
                if (IsOverlapping(reservationDetails.RoomId, reservationDetails.StartTime, reservationDetails.EndTime))
                {
                    ModelState.AddModelError(string.Empty, "This room is already reserved for the selected time.");
                    return View(reservationDetails);
                }

                // Get the current user's identity
                var currentUser = await _userManager.GetUserAsync(HttpContext.User);

                // Include the Room information in the reservation query
                var room = _context.Rooms.FirstOrDefault(r => r.Id == reservationDetails.RoomId);

                // Save reservation to the database
                var reservation = new Reservation
                {
                    RoomId = reservationDetails.RoomId,
                    Room = room,
                    StartTime = reservationDetails.StartTime,
                    EndTime = reservationDetails.EndTime,
                    UserName = currentUser.UserName // Use the user's username or any other identifier
                };

                _context.Reservations.Add(reservation);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            // If validation fails, return to the reservation form with errors
            return View(reservationDetails);
        }
        private bool IsOverlapping(int roomId, DateTime startTime, DateTime endTime)
        {
            // Check if there is any existing reservation for the selected room and overlapping time
            return _context.Reservations.Any(r =>
                r.RoomId == roomId &&
                ((startTime >= r.StartTime && startTime < r.EndTime) || (endTime > r.StartTime && endTime <= r.EndTime)));
        }


    }
}
