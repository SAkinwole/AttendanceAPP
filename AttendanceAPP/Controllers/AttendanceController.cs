using AttendanceAPP.Areas.Identity.Data;
using AttendanceAPP.Data;
using AttendanceAPP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceAPP.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly SignInManager<AttendanceAPPUser> _signInManager;
        private readonly UserManager<AttendanceAPPUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AttendanceController(
            SignInManager<AttendanceAPPUser> signInManager,
            UserManager<AttendanceAPPUser> userManager,
            ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();

            var attendanceViewModel = new List<AttendanceViewModel>();
            foreach (AttendanceAPPUser user in users)
            {
                var thisViewModel = new AttendanceViewModel();
                thisViewModel.Id = user.Id;
                thisViewModel.FirstName = user.Firstname;
                thisViewModel.LastName = user.LastName;
                thisViewModel.Email = user.Email;

                attendanceViewModel.Add(thisViewModel);
            }

            return View(attendanceViewModel);

        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var users = await _userManager.Users.ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = users.Where(n => string.Equals(n.LastName, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
                //var users = users.Where(s => s.LastName.Contains(searchString));


                return View("Index", filteredResultNew);
            }

            return View("Index", users);
        }

        //public async Task<IActionResult> Index(string searchString)
        //{
        //    var user = from m in _context.Users
        //                 select m;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        user = user.Where(s => s.LastName.Contains(searchString));
        //    }

        //    return View(await user.ToListAsync());
        //}
    }
}
