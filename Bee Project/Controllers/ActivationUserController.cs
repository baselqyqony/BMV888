using Bee_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Net;
using System.Net.Mail;
namespace Bee_Project.Controllers
{
    public class ActivationUserController : Controller
    {

          private ApplicationDbContext _context;

          public ActivationUserController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: ActivationUser
        public ActionResult Index()
        {
            return View();
        }
        public void SendActivationEmail(ApplicationUser user)
        {
            Guid activationCode = Guid.NewGuid();

            _context.UserActivations.Add(new UserActivations
            {
                UserID = user.Id,
                ActivationCode = activationCode
            });
            _context.SaveChanges();

            using (MailMessage mm = new MailMessage("mhmad.sabha89@gmail.com", user.Email))
            {
                mm.Subject = "Account Activation";
                string body = "Hello " + user.UserName + ",";
                body += "<br /><br />Please click the following link to activate your account";
                body += "<br /><a href = '" + string.Format("{0}://{1}/ActivationUser/Activation/{2}", Request.Url.Scheme, Request.Url.Authority, activationCode) + "'>Click here to activate your account.</a>";
                body += "<br /><br />Thanks";
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("sender@gmail.com", "<password>");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }

        public ActionResult Activation()
        {
            ViewBag.Message = "Invalid Activation code.";
            if (RouteData.Values["id"] != null)
            {
                Guid activationCode = new Guid(RouteData.Values["id"].ToString());
              
                UserActivations userActivation = _context.UserActivations.Where(p => p.ActivationCode == activationCode).FirstOrDefault();
                if (userActivation != null)
                {
                    _context.UserActivations.Remove(userActivation);
                    _context.SaveChanges();
                    ViewBag.Message = "Activation successful.";
                }
            }

            return View();
        }
    }
}