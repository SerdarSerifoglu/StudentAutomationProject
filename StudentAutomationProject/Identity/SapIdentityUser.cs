using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAutomationProject.Identity
{
    public class SapIdentityUser:IdentityUser
    {
        public Guid? PersonUID { get; set; }
        public int Type { get; set; }
    }
}
