using Business.Abstract;
using Business.Concrete.Answer;
using Business.Concrete.DependencyResolvers.Ninject;
using Business.Concrete.Subject;
using Data.Abstract;
using Data.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Ninject;
using System.Reflection;

namespace WorkFollow
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                  
                });
    }
}
