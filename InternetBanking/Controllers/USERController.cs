using InternetBanking.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternetBanking.Controllers
{
    public class USERController : Controller
    {
        private readonly UserContext _context;
        public USERController(UserContext context)
        {
            _context = context;
        }
        // GET: USERController
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel vm)
        {
            
                _context.Add(vm);
                _context.SaveChanges();
                ViewBag.Success = "Thanks for Register ! Your Account will be verified shortly....Your RequestID is "+vm.RequestID+" Kindly Note! for the verification Purposes";
                return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(RegisterViewModel vm)
        {
            var r = _context.registration.Where(x=> x.RegisteredMobileNo == vm.RegisteredMobileNo && x.RequestID==vm.RequestID).FirstOrDefault();


            if (r.UStatus == 1)
            {
                ViewBag.msg = "Your Account is verified .... :) ";
                
            }
            else if (r.UStatus == 0)
            {
                ViewBag.msg = "Your Account has not been verified yet.... :( ";

            }
            else
            {
                ViewBag.msg = "Your Account has been blocked.... :| ";
            }
            return View();
        }
    }
}
