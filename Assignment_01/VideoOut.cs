using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_01
{
    public class VideoOut
    {

        public delegate void VideoEncodedDelegate (object source, VideoEventArgs args);

        public event VideoEncodedDelegate videoRentedOut;

        delegate void ExpressionDelegate(List<Video> e);

        public void Rent()
        {
            string json = File.ReadAllText(@"./Data/Videos.json");
            var videos = JsonConvert.DeserializeObject<List<Video>>(json);

            var videoService = new VideoService();
            var mailService = new MailService();
            var messageService = new MessageService();

            messageService.Write(StaticMessage.Welcome);
            messageService.Write(StaticMessage.Menu);

            string hyphen = new string('-', 100);

            videos.ForEach(p =>{messageService.Write($"{hyphen}\nID:{p.Id,5}\tTITLE:{p.Title}\tAUTHOR:{p.Author}\tYEAR:{p.Year,4}\n{p.Description}"); });

            messageService.Write(hyphen);
            messageService.Write(StaticMessage.Guide);
            messageService.Write(StaticMessage.Options);


            ExpressionDelegate del = e => e.ForEach(p => { messageService.Write($"Title:{p.Title}\nYear:{p.Year}\n"); });

            do
            {
                string input = messageService.ReadAndWrite(StaticMessage.Selection);

                if (!input.IsValidSelection()) {
                    messageService.Write(StaticMessage.InvalidSelection);
                    continue;
                }

                if (input == "1")
                {
                    do
                    {
                        string ID = messageService.ReadAndWrite(StaticMessage.Rent);

                        if (!videos.FindAll(p => p.Id == ID).Any())
                        {
                            if (videos.FindAll(p => p.Id == ID).Count <= 0) messageService.Write(StaticMessage.InvalidID);
                            else messageService.Write(StaticMessage.InvalidID);
                            continue;
                        }
                        else {

                            this.videoRentedOut += messageService.OnVideoRentedOut;
                            this.videoRentedOut += mailService.OnVideoRentedOut;

                            var videoSelected = videos.FirstOrDefault(p => p.Id == ID);
                            videos = videoService.SetToNotAvailable(ID,videos);

                            OnVideoRentedOut(videoSelected);

                            this.videoRentedOut -= messageService.OnVideoRentedOut;
                            this.videoRentedOut -= mailService.OnVideoRentedOut;

                            break;
                        }
                    }
                    while (true);
                }

                if (input == "2")
                    del(videos);
                do
                {
                    string inputYesOrNo = messageService.ReadAndWrite(StaticMessage.Continue);

                    if (!inputYesOrNo.IsValidYesOrNo())
                    {
                        messageService.Write(StaticMessage.InvalidKeyword);
                        continue;
                    }
                    else {
                        if (inputYesOrNo.ToLower() == "y") break;
                        if (inputYesOrNo.ToLower() == "n") goto exit;
                    }
                }
                while (true);
            }
            while (true);

            exit:
            messageService.Write(StaticMessage.Closing);
            Console.ReadLine();
        }

        protected virtual void OnVideoRentedOut(Video? videos)
        {
            videoRentedOut?.Invoke(this, new VideoEventArgs { Video = videos });
        }
    }
}
