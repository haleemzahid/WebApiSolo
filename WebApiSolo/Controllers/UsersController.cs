using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiSolo.Models;

namespace WebApiSolo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        // GET: UsersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost("RegisterUSer")]
      
        public bool Create(TblUser user)
        {

            using (surebetdbContext db = new surebetdbContext())
            {
                if (!db.TblUsers.Any(x=>x.UserId==user.UserId))
                {
                    user.UserUid = Guid.NewGuid();
                    db.Add(user);
                }
                else
                {
                    var userFromDatabase = db.TblUsers.Where(x=>x.UserId==user.UserId).FirstOrDefault();
                    userFromDatabase.FirstName = user.FirstName;
                    userFromDatabase.LastName = user.LastName;
                    userFromDatabase.Email = user.Email;
                    userFromDatabase.Password = user.Password;
                }
                return db.SaveChanges() > 0;
            }



        }


        [HttpPost("Authenticate")]
        
        public TblUser GetUser(TblUser user)
        {
            using (surebetdbContext db=new surebetdbContext ())
            {
                var userFromDB = db.TblUsers.Where(x => x.Email.ToLower() == user.Email.ToLower() && x.Password == user.Password).FirstOrDefault();
                return userFromDB;
            }
        }

      
    }
}
