using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_06
{
    internal class HorseRacing
    {
        public void Run()
        {

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
            int totalWork = 100;
            int completedWork = 0;

            foreach (var runner in runners)
            {


                new Thread(() =>
                {
                    while (completedWork < totalWork)
                    {
                        Console.WriteLine();
                        completedWork++;

                        Console.Write("\r" + Thread.CurrentThread.Name.ToString() + ": [{0}{1}] {2}%", new string('#', completedWork), new string('-', totalWork - completedWork), completedWork);

                        if (completedWork == totalWork)
                        {
                            Console.WriteLine("\nWinner: " + Thread.CurrentThread.Name.ToString());
                        }
                        Thread.Sleep(100);
                    }

                })
                {
                    /*Thread Name*/
                    Name = runner.Name,

                    /*Thread Priority*/
                    Priority = runner.Speed >= 4 ? ThreadPriority.Highest : (ThreadPriority)runner.Speed
                }.Start();
            }
            Console.ReadKey();
        }

        public int GetRandomSpeed()
        {
            var random = new Random();
            return random.Next(1, 6);
        }

    }

}
