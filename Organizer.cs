using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ConsoleApp1
{
    public class Organizer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? CompanyName { get; set; }

        public bool IsVerified { get; set; }

        public string? Bio { get; set; }

        public string? Website { get; set; }

        public string? Logo { get; set; }

        // Navigation
        public List<Event> Events { get; set; } = new();
    }
}
