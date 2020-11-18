using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skaitykla.MVC
{
    public class LibraryUser: IdentityUser
    {
        public DateTime AttendFrom { get; set; }
    }
}
