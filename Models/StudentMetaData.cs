using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementApp.MVC.Data;

    public class StudentMetaData
    {
        [StringLength(15)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [StringLength(15)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;
        
        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

    }

[ModelMetadataType(typeof(StudentMetaData))]
public partial class Student{}