﻿using System;

namespace WindowsFormsApp2
{
    public class Income
    {
        public string Category { get; set; }
        public string Comment { get; set; }
        public decimal Cost { get; set; }
        public DateTime Date { get; set; }
        public Account Account { get; set; }
    }
}
