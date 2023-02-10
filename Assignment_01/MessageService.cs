using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_01
{
    public class MessageService
    {
        public void OnVideoRentedOut(object source, VideoEventArgs e)
        {
            Write("Successfully rented.\n" +
                "Details:\n" +
                $"\tID: {e.Video.Id}\n" +
                $"\tTitle: {e.Video.Title}\n");
        }

        public void Write(string message) {
            Console.WriteLine(message);
        }

        public string ReadAndWrite(string message) {
            Console.Write(message);
            return Console.ReadLine();
        }
    }


}
