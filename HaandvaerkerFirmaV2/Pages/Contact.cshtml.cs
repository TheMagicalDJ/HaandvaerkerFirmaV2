using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Linq.Expressions;

namespace HaandvaerkerFirmaV2.Pages
{
    public class ContactModel : PageModel
    {
        /// <summary>
        /// Properties til forsendelse af en KontaktFormular.
        /// </summary>

        [Required(ErrorMessage = "DU skal indtaste et navn.")]
        [MaxLength(50), MinLength(3, ErrorMessage = "Navnet skal mindst være på 3 tegn.")]
        [BindProperty]
        public string KFNavn { get; set; }

        [Required(ErrorMessage = "Du skal indtaste et mobilt nummer.")]
        [Phone, MaxLength(30), MinLength(4, ErrorMessage = "Nummeret skal mindst være på 4 tegn.")]
        [BindProperty]
        public string KFMobilnummer { get; set; }

        [Required(ErrorMessage = "Du skal indtaste en Email.")]
        [EmailAddress]
        [MaxLength(60), MinLength(5, ErrorMessage = "Mailen skal mindst være på 5 tegn.")]
        [BindProperty]
        public string KFEmail { get; set; }

        [Required(ErrorMessage = "Du skal indtaste en Besked.")]
        [MaxLength(300), MinLength(30, ErrorMessage = "Beskeden skal mindst være på 30 tegn.")]
        [BindProperty]
        public string KFBesked { get; set; }

        /// <summary>
        /// Property til at tilmelde sig Nyhedsbrev.
        /// </summary>
        [Required]
        [EmailAddress, MaxLength(60), MinLength(20)]
        [BindProperty]
        public string NBEmail { get; set; }

        public void OnGet()
        {
        }

        public void OnPost(string KFnavn, string KFMobilnummer, string KFEmail, string KFBesked, string NBEmail)
        {
            if (!ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpserver = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("crimsonblood0003@gmail.com");
                mail.To.Add(KFEmail);
                mail.Subject = "Testing Testing";
                mail.Body = KFBesked;

                smtpserver.Port = 587;
                smtpserver.Credentials = new System.Net.NetworkCredential("crimsonblood0003@gmail.com", "kode6310");
                smtpserver.EnableSsl = true;

                smtpserver.Send(mail);
            }
            else
            {

            }
        }
    }
}
