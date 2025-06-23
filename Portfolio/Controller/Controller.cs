using System;
using System.Linq;
using Domain.Interfaces.IServices;

namespace Presentation.Controller
{
    public class Controller
    {
        private readonly IService _service;

        public Controller(IService service)
        {
            _service = service;
        }

        public void Run()
        {
            Console.WriteLine("Portfolio of Indira Tovinakere Rajesh");
            Console.WriteLine("Enter your choice: \n1. View All Info \n2. Exit");

            string choice;
            choice=Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var infos = _service.GetAllAsync().Result;
                    if (infos.Any())
                    {
                        foreach (var info in infos)
                        {
                            Console.WriteLine($"Slno: {info.Slno}, Name: {info.Name}, Education: {info.Education}, Phone: {info.Phonenumber}, Email: {info.EmailId}, Address: {info.Address}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No information available.");
                    }
                    break;

                case "2":
                    Console.WriteLine("Exiting the application.");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
