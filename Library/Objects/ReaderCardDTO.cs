﻿using System;
using System.Collections.Generic;

namespace Library.Objects
{
    public class ReaderCardDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public DateTime DateOfRegistration { get; set; }

        public ReaderCardDTO() { }
        public ReaderCardDTO(int id, string name, string surname, int age, string email, DateTime dateOfReceiving)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
            Email = email;
            DateOfRegistration = dateOfReceiving;
        }
    }
}