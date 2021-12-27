using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GutenbergBookshelf.Models
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Max 50 characters!")]
        public string Username { get; set; }
        [StringLength(50, ErrorMessage = "Max 50 characters!")]
        public string Name { get; set; }
        [StringLength(50, ErrorMessage = "Max 50 characters!")]
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string AboutMe { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Gender { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
