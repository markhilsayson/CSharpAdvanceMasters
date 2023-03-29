using Assignment_01.Data;
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
            //string json = File.ReadAllText(@"./Data/Videos.json");
            //var videos = JsonConvert.DeserializeObject<List<Video>>(json);

            VideoDbContext dbContext = new VideoDbContext();
            var videos = dbContext.Videos.ToList();

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
                videos=dbContext.Videos.ToList();
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

                //Add a Video
                if (input == "3")
                {
                    var vid = new Video();
                    Console.Write("ID: ");
                    vid.Id = Console.ReadLine();
                    Console.Write("Author: ");
                    vid.Author = Console.ReadLine();
                    Console.Write("Description: ");
                    vid.Description = Console.ReadLine();
                    Console.Write("Title: ");
                    vid.Title = Console.ReadLine();
                    Console.Write("Year: ");
                    vid.Year = Console.ReadLine();
                    dbContext.Videos.Add(vid);
                    dbContext.SaveChanges();
                    dbContext.Videos.ToList().ForEach(p => { messageService.Write($"{hyphen}\nID:{p.Id,5}\tTITLE:{p.Title}\tAUTHOR:{p.Author}\tYEAR:{p.Year,4}\n{p.Description}"); });
                    Console.WriteLine("Successfully added.");
                }

                //Delete a Video
                if (input == "4") {
                    Console.Write("Please provide an ID to delete: ");
                    string tempID = Console.ReadLine();
                    var vid = videos.FirstOrDefault(x => x.Id == tempID);
                    dbContext.Videos.Remove(vid);
                    dbContext.SaveChanges();
                    dbContext.Videos.ToList().ForEach(p => { messageService.Write($"{hyphen}\nID:{p.Id,5}\tTITLE:{p.Title}\tAUTHOR:{p.Author}\tYEAR:{p.Year,4}\n{p.Description}"); });

                    Console.WriteLine("Deleted Successfully.");
                }

                //filter by year
                if (input == "5") {
                    Console.Write("Please provide a year:");
                    string tempYear=Console.ReadLine();
                    var vid=videos.FindAll(x => x.Year == tempYear);
                    vid.ForEach(p => { Console.Write($"{hyphen}\nID:{p.Id,5}\tTITLE:{p.Title}\tAUTHOR:{p.Author}\tYEAR:{p.Year,4}\n{p.Description}\n"); });    
                }

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
