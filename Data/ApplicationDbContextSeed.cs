using System;
using System.Linq;

public static class ApplicationDbContextSeed
{
    public static void SeedData(ApplicationDbContext context)
    {
        //if (!context.Rooms.Any())
        //{
        //    context.Rooms.Add(new Room { Name = "Meeting Room A", Capacity = 10 });
        //    context.Rooms.Add(new Room { Name = "Conference Room B", Capacity = 20 });
        //    context.SaveChanges();
        //}

        //if (!context.Reservations.Any())
        //{
        //    var roomId = context.Rooms.First().Id;

        //    context.Reservations.Add(new Reservation
        //    {
        //        RoomId = roomId,
        //        UserName = "Tijs",
        //        StartTime = DateTime.Now.AddHours(1),
        //        EndTime = DateTime.Now.AddHours(2)
        //    });

        //    context.SaveChanges();
        //}
    }
}

