using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Helper
{
    public static class EmailSettings
    {
        public static void SendEmail(Email Input)
        {
            var Client=new SmtpClient("smtp.gmail.com",587);
            Client.EnableSsl = true;
            Client.Credentials = new NetworkCredential("hemaabokhalil677@gmail.com", "lbditkpsyviivboa");
            Client.Send("hemaabokhalil677@gmail.com", Input.To, Input.Subject, Input.Body);
        }
    }
}
