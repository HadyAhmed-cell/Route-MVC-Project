using Route.NetDAL.Entities;
using System.Net;
using System.Net.Mail;

namespace Route.NetPL.Helper
{
    public class EmailSettings
    {

        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.ethereal.email", 587);
            client.EnableSsl = true;

            client.Credentials = new NetworkCredential("monique17@ethereal.email", "8F6Td4RNvp3fK7U495");

            client.Send("Ahmed@gmail.com", email.To, email.Title, email.Body);
        }
    }
}
