﻿namespace global2.NET.Database.Models
{
    public class Address
    {
        public long AddressId { get; set; }
        public string Street { get; set; }
        public string CEP { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
