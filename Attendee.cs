using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Attendee
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public Address Address { get; set; }

        public Badge? Badge { get; set; }

        public List<Registration> Registrations { get; set; } = new();
    }
}
