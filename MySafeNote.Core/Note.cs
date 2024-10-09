﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MySafeNote.Core
{
    public class Note
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public Guid BodyLink { get; set; }
        public string NotePassword { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastChangeDate { get; set; }

    }
}