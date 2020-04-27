using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private int? UserSession
        {
            get{return HttpContext.Session.GetInt32("UserId");}
            set{ HttpContext.Session.SetInt32("UserId", (int)value);}
        }
        private Context dbContext;
        public HomeController(Context context){
            dbContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("new/user")]
        public IActionResult register (User newUser) {
            if (ModelState.IsValid) {
                User exists = dbContext.Users.FirstOrDefault (p => p.email == newUser.email);
                if (exists != null) {
                    ModelState.AddModelError ("email", "email already taken.");
                    return View ("Index");
                } else {
                    PasswordHasher<User> Hasher = new PasswordHasher<User> ();
                    newUser.password = Hasher.HashPassword (newUser, newUser.password);
                    dbContext.Add (newUser);
                    dbContext.SaveChanges ();
                    UserSession=newUser.UserId;
                    return RedirectToAction ("success");
                }
            }
            return View ("Index");
        }

        [HttpPost("login")]
        public IActionResult login (Login user) {
            if (ModelState.IsValid) {
                User userInDb = dbContext.Users.FirstOrDefault (p => p.email == user.LoginEmail);
                if (userInDb == null) {
                    ModelState.AddModelError ("LoginEmail", "Invalid Email/Password");
                    return View ("Index");
                }
                var hasher = new PasswordHasher<Login> ();
                var result = hasher.VerifyHashedPassword (user, userInDb.password, user.LoginPassword);
                if (result == 0) {
                    ModelState.AddModelError ("LoginPassword", "Invalid Email/Password");
                    return View ("Index");
                } else {
                    UserSession = userInDb.UserId;
                    return RedirectToAction ("success");
                }
            } else {
                return View ("Index");
            }
        }

        [HttpGet("User/success")]
        public IActionResult success()
        {
            if(UserSession==null)
            {
                return RedirectToAction("Index");
            }
            User user = dbContext.Users.FirstOrDefault(q => q.UserId == UserSession);
            List<Wedding> allW = dbContext.Weddings.Include(w =>w.CreatedRsvp).Include(q => q.Creator).ToList();
            dashboard model = new dashboard();
            model.userLogged = user;
            model.weddingList = allW;
            return View(model);
        }

        [HttpGet("User/Create")]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost("User/CreateWedding")]
        public IActionResult CreateWedding(Wedding createInvites)
        {
            if( UserSession == null)
            {
                return RedirectToAction("Index");
            }
            if(ModelState.IsValid)
            {
                createInvites.Userid = (int) UserSession;
                //creator is a userreg class so it has the userid
                
                dbContext.Weddings.Add(createInvites);
                dbContext.SaveChanges();
                return RedirectToAction("ShowWedding", new{weddingId=createInvites.WeddingId});
            }
            else{
                return View("Create");
            }
        }
        [HttpGet("ShowWedding/{weddingId}")]
        public IActionResult ShowWedding(int weddingId)
        {
            if( UserSession == null)
            {
                return RedirectToAction("Index");
            }
            Wedding showWedding = dbContext.Weddings.Include(x=>x.CreatedRsvp).ThenInclude(x => x.Guest).FirstOrDefault(x=>x.WeddingId==weddingId);
            return View(showWedding);

        }

        [HttpPost("rsvptoyourwedding/{WeddingId}")]
        public IActionResult Rsvp(int WeddingId)
        {
            if( UserSession == null)
            {
                return RedirectToAction("Index");
            }
            Rsvp going = new Rsvp();
            going.WeddingId = WeddingId;
            going.UserId = (int)UserSession;
            dbContext.Rsvp.Add(going);
            dbContext.SaveChanges();
            return RedirectToAction("success");

        }
        [HttpPost("notgoingtoyourwedding/{WeddingId}")]
        public IActionResult UnRsvp(int WeddingId)
        {
            if( UserSession == null)
            {
                return RedirectToAction("Index");
            }
            Rsvp Notgoing = dbContext.Rsvp.FirstOrDefault(x => x.WeddingId == WeddingId && x.UserId == UserSession);
            dbContext.Rsvp.Remove(Notgoing);
            dbContext.SaveChanges();
            return RedirectToAction("success");

        }
        [HttpPost("delte/wedding/{WeddingId}")]
        public IActionResult delete(int WeddingId)
        {
            Wedding wedtoDel = dbContext.Weddings.FirstOrDefault(x=> x.WeddingId == WeddingId);
            dbContext.Weddings.Remove(wedtoDel);
            dbContext.SaveChanges();
            return RedirectToAction("success");
        }















        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
