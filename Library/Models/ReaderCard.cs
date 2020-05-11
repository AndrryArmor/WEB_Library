﻿using System;
using System.Collections.Generic;

namespace Library.Models
{
    public class ReaderCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public DateTime DateOfReceiving { get; set; }

        public ReaderCard(int id, string name, string surname, int age, string email, DateTime dateOfReceiving)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
            Email = email;
            DateOfReceiving = dateOfReceiving;
        }
    }
}