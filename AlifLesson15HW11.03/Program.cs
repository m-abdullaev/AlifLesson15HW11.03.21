using AlifLesson15HW11._03.AlifContext;
using AlifLesson15HW11._03.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AlifLesson15HW11._03
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(@"1. Read"+
                                    "2. Delete"+
                                    "3. Create"+
                                    "4. Update");
                switch (Console.ReadLine())
                {
                    case "1":
                        await Read();
                        break;
                    case "2":
                        await Delete();    
                        break;
                    case "3":
                        await Create();
                        break;
                    case "4":
                        await Update();
                        break;
                }

            }
        }
        private static async Task Delete()
        {
            Console.Write("Id:");
            var id = int.Parse(Console.ReadLine());
            using (var alifCtx = new MyContext())
            {
                var persons = await alifCtx.Persons.FindAsync(id);
                alifCtx.Remove(persons);
                try
                {
                    await alifCtx.SaveChangesAsync();
                }
                catch (System.Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }
        }
        private static async Task Create()
        {
            var @newPerson = new Person();
            
            Console.WriteLine("LastName: ");
            newPerson.LastName = Console.ReadLine();

            Console.WriteLine("FirstName: ");
            newPerson.FirstName = Console.ReadLine();

            Console.WriteLine("MiddleName: ");
            newPerson.MiddleName = Console.ReadLine();

            Console.WriteLine("Date of birth: ");
            newPerson.BirthDate = DateTime.Parse(Console.ReadLine());

            using (var ctx = new MyContext())
            {
                ctx.Persons.Add(newPerson);
                await ctx.SaveChangesAsync();
            }
        }
        static async Task Read()
        {
            
            using (var alifCtx = new MyContext())
            {
                var persons = alifCtx.Persons;
                await persons.ForEachAsync(p => Console.WriteLine($"Id:{p.Id}\tFirstName:{p.FirstName}")); 
            }
        }
        private static async Task Update()
        {
            Console.WriteLine("Id:");
            var id = int.Parse(Console.ReadLine());
            using (var alifCtx = new MyContext())
            {
                var persons = await alifCtx.Persons.FindAsync(id);
                Console.WriteLine("LastName:");
                persons.LastName = Console.ReadLine();

                Console.WriteLine("FirstName:");
                persons.FirstName = Console.ReadLine();

                Console.WriteLine("MiddleName:");
                persons.MiddleName = Console.ReadLine();

                Console.WriteLine("Date of Birth:");
                persons.BirthDate = DateTime.Parse( Console.ReadLine());

                await alifCtx.SaveChangesAsync();
            }

        }
    }
}
