﻿using System;

public class Room
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public ICollection<Reservation> Reservations { get; set; }

    // Add other properties as needed


}
