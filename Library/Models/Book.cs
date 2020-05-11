﻿using System.Collections;
using System.Collections.Generic;

namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Chapter> Chapters { get; set; }
        public List<AuthorBook> AuthorBooks { get; set; }

        public Book()
        {
            Chapters = new List<Chapter>();
            AuthorBooks = new List<AuthorBook>();
        }
    }
}