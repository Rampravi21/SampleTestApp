using System;
using System.ComponentModel.DataAnnotations;

namespace RoomReservationApp.Models
{
    public class ReservationDetailsViewModel
    {
        [Required]
        public int RoomId { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }
    }

}
