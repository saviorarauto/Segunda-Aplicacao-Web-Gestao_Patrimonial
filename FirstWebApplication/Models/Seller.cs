﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestao_Patrimonial.Models
{
    public class Seller
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between 3 and 60")] // ou "Name size should be between 3 and 60")
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [Required(ErrorMessage = "{0} required")]
        public string Email { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required (ErrorMessage ="{0} required")]
        [DataType(DataType.Date)]
        [Display(Name = "BirthDate Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double BaseSalary { get; set; }

        [Display(Name = "BirthDate Date")]
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
        


    }
}
