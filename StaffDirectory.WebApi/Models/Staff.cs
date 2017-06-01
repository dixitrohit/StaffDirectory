using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaffDirecotry.WebAPI.Models
{
    /// <summary>
    /// Staff Entities
    /// </summary>
    public class Staff
    {
        public int StaffID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
    }
}