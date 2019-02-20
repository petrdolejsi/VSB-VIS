using System;

namespace Library.Models
{
    public class Gp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Circuit { get; set; }
        public DateTime Date { get; set; }
        public double? Lenght { get; set; }
        public int? Laps { get; set; }
        public States State { get; set; }
        public int? UserId { get; set; }
    }
}
