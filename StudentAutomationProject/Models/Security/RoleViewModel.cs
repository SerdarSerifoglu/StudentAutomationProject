using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAutomationProject.Models.Security
{
    public class RoleViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
