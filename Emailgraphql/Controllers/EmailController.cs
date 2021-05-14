using Emailgraphql.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Emailgraphql.SendingLetter;


namespace Emailgraphql.Controllers
{
    public class EmailController : Controller
    {

        private EmailContext db;
        public EmailController(EmailContext context)
        {
            db = context;
        }


        public IActionResult Send()
        {


            return View();
        }

        [HttpPost]
        public IActionResult Send(string email, string topic, string fromwho, string letter)  // string topic // string message
        {
            SendEmail send = new SendEmail();
            //  EmailStatus status = new EmailStatus();

            if (email.Contains(" "))
            {

                string[] emails = email.Split(" ");
                for (int i = 0; i < emails.Length; i++)
                {
                    EmailStatus status = new EmailStatus();
                    status.SentTo = emails[i];
                    status.Status = "Отправляется";
                    status.Status = send.Email(emails[i], topic, fromwho, letter);
                    db.EmailsStatus.Add(status);
                    db.SaveChanges();
                }
            }
            else
            {
                EmailStatus status = new EmailStatus();
                status.SentTo = email;
                status.Status = "Отправляется";
                status.Status = send.Email(email, topic, fromwho, letter);
                db.EmailsStatus.Add(status);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
