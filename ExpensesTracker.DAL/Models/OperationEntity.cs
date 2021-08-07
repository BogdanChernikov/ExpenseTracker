﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpensesTracker.DAL
{
    [Table("Operations")]
    public class OperationEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public string Comment { get; set; }

        public int AccountId { get; set; }
    }
}