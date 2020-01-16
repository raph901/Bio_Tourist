using System.Web.Mvc;
using Antlr.Runtime.Misc;

namespace Bio_Tourist.Models
{
    public class UserRegistation
    {
        public ActionResult AddOrEdit(int id = 0)
        {
            User userModel = new User();
            return View(userModel);
        }
    }
}