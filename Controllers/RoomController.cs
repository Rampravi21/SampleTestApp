using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace RoomReservationApp.Controllers
{

    public class RoomController : Controller
    {
        private readonly ILogger<RoomController> _logger;

        private readonly ApplicationDbContext _context;

        public RoomController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var rooms = _context.Rooms.ToList();
            return View(rooms);
        }

    }
}
