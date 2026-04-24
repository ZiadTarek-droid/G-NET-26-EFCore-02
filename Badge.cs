using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1
{
    public class Badge
    {
        public int Id { get; set; }

        [Required]
        public string BadgeNumber { get; set; }

        public DateTime IssuedDate { get; set; }

        public string Tier { get; set; } // Standard / VIP

        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; }
    }
}
