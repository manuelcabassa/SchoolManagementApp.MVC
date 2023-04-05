using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementApp.MVC.Data;

    public class LecturersMetaData
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;
        
    }

    [ModelMetadataType(typeof(LecturersMetaData))]
    public partial class Lecturers{}
