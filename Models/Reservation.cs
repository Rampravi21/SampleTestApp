using System;

public class Reservation
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string UserName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Room Room { get; set; }
    // Add other properties as needed

}
