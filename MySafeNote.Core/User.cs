﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MySafeNote.Core
{
   public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
