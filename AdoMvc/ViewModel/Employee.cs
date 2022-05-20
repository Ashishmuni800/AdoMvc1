using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdoMvc.ViewModel
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string IsActive { get; set; }
        public string Department { get; set; }
    }
}