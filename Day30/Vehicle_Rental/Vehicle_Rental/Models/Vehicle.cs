﻿using System.ComponentModel.DataAnnotations;

namespace Vehicle_Rental.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public decimal DailyRate { get; set; }
        public string? Status { get; set; }
        public int PassengerCapacity { get; set; }
        public decimal EngineCapacity { get; set; }


    }
}
