using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epidemi
{
    class Program
    {
        static void Main(string[] args)
        {

            var diskotek = new List<Person>();
            for (int i = 0; i < 50; i++)
            {
                var person = new Person();
                person.Smittad = false;
                person.Immun = false;
                diskotek.Add(person);
            }
            
            diskotek[0].Smittad = true;
            diskotek[0].Smittadnär = 0;
            int tid = 0;
            
            
            
            while (true)
            {
                foreach (var person in diskotek)
                {
                    X(person);
                }
                Console.WriteLine();
                Console.WriteLine($"Tid: {tid} timmar");
                Console.WriteLine($"Antal Smittade: {diskotek.Count(x => x.Smittad)}");
                Console.WriteLine($"Antal Immuna: {diskotek.Count(x => x.Immun)}");
                Console.ReadKey();
                tid++;
                
               
               foreach(var person in diskotek)
                {
                   
                    if (person.Smittad && person.Smittadnär < tid)
                    {
                        foreach(var smittoffer in diskotek)
                        {
                            if (smittoffer.Smittad == false && smittoffer.Immun == false)
                            {
                                smittoffer.Smittad = true;
                                smittoffer.Smittadnär = tid;
                                break;
                            }
                        }
                    }
                    if (person.Smittad && tid - person.Smittadnär >= 5)
                    {
                        person.Smittad = false;
                        person.Immun = true;
                    }
                }
                Console.Clear();
                
               
                

                




            }
        }
        static void X(Person person)
        {
            if (person.Smittad)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("X ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (person.Immun)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("X ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write("X ");
            }
            
        }
    }
    class Person
    {
        public bool Smittad { get; set; }
        public bool Immun { get; set; }
        public int Smittadnär { get; set; }

    }
}
