using System;
using System.ComponentModel.DataAnnotations;

namespace MySafeNote.Core
{
   public class User : BaseEntity
    {
        [Required]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
