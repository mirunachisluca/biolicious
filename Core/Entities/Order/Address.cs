using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Order
{
    
    public class Address
    {
        public Address()
        {
        }

        public Address(string firstName, string lastName, string phoneNumber, string street, string city, 
            string county, string zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Street = street;
            City = city;
            County = county;
            ZipCode = zipCode;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string ZipCode { get; set; }
    }
}
