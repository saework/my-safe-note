using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MySafeNote.Core
{
   public class User
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
