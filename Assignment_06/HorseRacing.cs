using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_06
{
    internal class HorseRacing
    {
        public void Run() {
            
            var runners = new List<Horse>();
            for (int i = 1; i <= 5; i++)
            {
                var runner = new Horse($"Horse{i}");
                runner.SetSpeed(GetRandomSpeed());
                runners.Add(runner);
            }

            Console.WriteLine("Welcome to Horse Racing Game!");
            Console.WriteLine("Please place your bet for one of the horses (1-5):");
            
            int bet;

            while (!int.TryParse(Console.ReadLine(), out bet) || bet < 1 || bet > 5)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5:");
            }

            Console.WriteLine("Starting the race...");
            var raceFinishedEvent = new ManualResetEvent(false);
       
            foreach (var runner in runners)
            {
                new Thread(() =>
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} is starting to run.");
                    while (!raceFinishedEvent.WaitOne(0))
                    {
                        runner.Move();
                    }
                })
                {
                    Name = runner.Name,
                    Priority = runner.Speed >= 4 ? ThreadPriority.Highest : (ThreadPriority)runner.Speed
                }.Start();
            }

            raceFinishedEvent.Set();

            Console.WriteLine("Results:");
            runners.Sort((h1, h2) => h2.Position.CompareTo(h1.Position));

            int ctr = 1;
            foreach (var runner in runners)
            {
                string awardPosition = string.Empty;
                switch (ctr) {
                    case 1: awardPosition = "1st"; break;
                    case 2: awardPosition = "2nd"; break;
                    case 3: awardPosition = "3rd"; break;
                    case 4: awardPosition = "4th"; break;
                    case 5: awardPosition = "5th"; break;
                }
                Console.WriteLine($"{runner.Name} {awardPosition} winner.");
                ctr++;
            }

            if (runners[bet - 1].Position == runners[0].Position)
            {
                Console.WriteLine($"Congratulations! {runners[bet - 1].Name} won the race.");
            }
            else
            {
                Console.WriteLine($"Sorry, {runners[bet - 1].Name} did not win the race.");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        public int GetRandomSpeed()
        {
            var random = new Random();
            return random.Next(1, 6);
        }
    }
}
