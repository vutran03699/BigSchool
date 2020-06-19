using BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BigSchool.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcomingCourses = _dbContext.Courses
                .Include(c => c.Lecturer)
                .Include(c => c.Category )
                .Where(c => c.DateTime > DateTime.Now);
            return View(upcomingCourses);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Trang mô tả ứng dụng của bạn.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Trang liên hệ của bạn.";

            return View();
        }
    }
}