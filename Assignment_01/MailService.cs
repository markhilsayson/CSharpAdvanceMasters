using System.Net;
using System.Net.Mail;

namespace Assignment_01
{
    public class MailService
    {

        public void OnVideoRentedOut(object source, VideoEventArgs e)
        {
            try
            {
                var client = new SmtpClient("smtp-relay.sendinblue.com", 587)
                {
                    Credentials = new NetworkCredential("markhilsison@gmail.com", "Nw3GKREmCjxJXIfU"),
                    EnableSsl = true
                };
                client.Send("markhilsison@gmail.com", "gjgceredon@gmail.com", e.Video.Title +$" Rental Confirmed",$"Hello,<br><br> Your rental video of {e.Video.Title} is confirmed. <br><br> This is an automatic email, so please don't reply.<br><br> Enjoy the Video!" );
            }
            catch (Exception ex) { }
        }
    }
}
