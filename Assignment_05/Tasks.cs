using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_05
{
    public class Tasks
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        
        public async Task Run() {

            CancellationToken cancellationToken = cancellationTokenSource.Token;

            Console.WriteLine("To cancel the tasks running press Ctrl+C.");
            Console.Write("Do you want to run all the tasks? Press Y/y: ");
            string result = Console.ReadLine();

            if (result.ToLower() == "y") {
                await Task.WhenAll(
                    Task.Run(() => Cancel()),
                    GetApiResponse("www.google.com", cancellationToken),
                    Task.Run(() => LoopAndPrint(cancellationToken)),
                    Task.Run(()=>CalculateSum(500,500,cancellationToken)),
                    Download(cancellationToken),
                    AddStaticValues(cancellationToken)
                    );
            }

            Console.WriteLine("All tasks are completed.");
        }

        private void Cancel() {
            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                Console.WriteLine("Cancel event triggered"); ;
                cancellationTokenSource.Cancel();
                eventArgs.Cancel = true;
            };
        }

        private void LoopAndPrint(CancellationToken cancellationToken)
        {
            Console.WriteLine("Loop and print every seconds is running.");
            int count = 0;
            while (!cancellationToken.IsCancellationRequested)// && count < 20)
            {
                Console.WriteLine($"{count + 1} sec(s)");
                count++;

                Task.Delay(1000, cancellationToken);
            }
        }

        public void CalculateSum(int x, int y, CancellationToken cancellationToken)
        {
            Console.WriteLine("Calculate Sum is running.");
            int sum = x + y;
            Console.WriteLine($"Sum: {x} + {y} = {sum}");
        }

        public async Task<string> GetApiResponse(string url, CancellationToken cancellationToken)
        {
            Console.WriteLine("Return a response from api/websites is running.");
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url, cancellationToken);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task Download(CancellationToken cancellationToken) {
            Console.WriteLine("Download file is running.");
            using WebClient client = new WebClient();
            client.DownloadDataAsync(new Uri("https://www.google.com"), cancellationToken);
            Console.WriteLine("Downloaded sample.txt");
        }

        public async Task ProgressBar(List<Task> tasks, CancellationToken cancellationToken)
        {
            const int totalSteps = 100;
            int completedSteps = 0;

            while ( !Task.WhenAll(tasks).IsCompleted)
            {
                Console.Write("[");
                int progress = (int)(100.0 * completedSteps / totalSteps);
                for (int i = 0; i < totalSteps; i += 5)
                {
                    if (i < progress)
                    {
                        Console.Write("=");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write($"] {progress}%\r");
                await Task.Delay(TimeSpan.FromMilliseconds(50), cancellationToken);
                completedSteps++;
                if (completedSteps >= totalSteps)
                {
                    completedSteps = 0;
                }
            }

            Console.WriteLine();
        }

        public async Task<List<string>> AddStaticValues(CancellationToken cancellationToken)
        {
            Console.WriteLine("Add Static Values into List is running.");
            List<string> staticList = new List<string>();

            if (!cancellationToken.IsCancellationRequested) {
                staticList.Add("sample");
                staticList.Add("sample1");
                staticList.Add("sample2");
            }
            return staticList;
        }




    }
}
