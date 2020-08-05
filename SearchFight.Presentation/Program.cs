using Microsoft.Extensions.DependencyInjection;
using SearchFight.Presentation.Controllers;
using System;

namespace SearchFight.Presentation
{
    class Program
    {
        static void Main(string[] args )
        {
            try
            {
                Search(args);
                
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Sorry, something bad happened. Message: {e.Message}");
                //Log error
            }
            
        }

        static void Search(string[] args)
        {
            var startup = new Startup();
            startup.ConfigureServices();
            var controller = startup.Provider.GetRequiredService<ISearchController>();
            controller.Search(args);
        }
    }
}
