using AttendanceAPP.Areas.Identity.Data;
using AttendanceAPP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceAPP.Data
{
    public class ApplicationDbContext : IdentityDbContext<AttendanceAPPUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        

    }
}
