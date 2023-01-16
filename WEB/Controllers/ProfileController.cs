using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;

using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace MvcProjeKampi.Controllers
{
    public class ProfileController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());

        [HttpGet]
        public ActionResult Profile()
        {

            //var userValues = um.GetById(1);
            //return View(userValues);

            Context c = new Context();
            var usermail = User.Identity.Name;
            var ID = c.Users.Where(x => x.Email == usermail).
                Select(y => y.Id).FirstOrDefault();
            var userValues = um.GetById(ID);
            return View(userValues);
        }

       
    }
}