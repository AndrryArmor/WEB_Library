﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Eventing.Reader;

namespace Library.Entities
{
    public class Record
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public DateTime DateOfReceiving { get; set; }
        public Reader Reader { get; set; }
    }
}