using System;
using System.Collections.Specialized;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;
using QuartzWithCore.Tasks;
namespace GSoft.AbpZeroTemplate.Web.Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                LogProvider.SetCurrentLogProvider(new ConsoleLogProvider());
                RunProgram().GetAwaiter();//.GetAwaiter().GetResult();
                CreateWebHostBuilder(args)
                    .Build()
                    .Run();             
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        private static async Task RunProgram()
        {
            try
            {
                // Grab the Scheduler instance from the Factory
                NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                IScheduler scheduler = await factory.GetScheduler();

                // and start it off
                await scheduler.Start();

                // define the job and tie it to our HelloJob class
                IJobDetail job = JobBuilder.Create<KH>()
                    .WithIdentity("job1", "group1")
                    
                    .Build();
                    
                // Trigger the job to run now, and then repeat every 10 seconds

                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("trigger1", "group1")
                    .StartNow()
                    .ForJob("job1","group1")
                    .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(0,0)) // execute job daily at 00:00
                    .Build();

                // Tell quartz to schedule the job using our trigger
                await scheduler.ScheduleJob(job, trigger);

                // some sleep to show what's happening
                //await Task.Delay(TimeSpan.FromSeconds(60));

                // and last shut down the scheduler when you are ready to close your program
                //await scheduler.Shutdown();
            }
            catch (SchedulerException se)
            {
                Console.WriteLine(se);
            }
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return new WebHostBuilder()
                .UseKestrel(opt => opt.AddServerHeader = false)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>();
        }
        private class ConsoleLogProvider : ILogProvider
        {
            public Logger GetLogger(string name)
            {
                return (level, func, exception, parameters) =>
                {
                    if (level >= LogLevel.Info && func != null)
                    {
                        Console.WriteLine("[" + DateTime.Now.ToLongTimeString() + "] [" + level + "] " + func(), parameters);
                    }
                    return true;
                };
            }

            public IDisposable OpenNestedContext(string message)
            {
                throw new NotImplementedException();
            }

            public IDisposable OpenMappedContext(string key, string value)
            {
                throw new NotImplementedException();
            }
        }
    }
    public class HelloJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Console.Out.WriteLineAsync("Greetings from HelloJob!");
        }
    }
}
