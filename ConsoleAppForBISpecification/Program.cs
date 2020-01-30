using System;
using System.Collections.Generic;
using BusinessIdSpecification;

namespace ConsoleAppForBISpecification
{
    class Program
    {
        static void Main(string[] args)
        {
            bool cont = true;
            while (cont)
            {
                Console.WriteLine("Enter Business ID to validate or enter 0 to exit the app: ");
                var bId = Console.ReadLine();

                if(bId == "0")
                {
                    cont = false;
                    Console.Write("Exitting application");
                    Environment.Exit(0);
                }

                BusinessIdSpecification.BusinessIdSpecification bIdValidator = new BusinessIdSpecification.BusinessIdSpecification();
                bool success = bIdValidator.IsSatisfiedBy(bId);
                string validStatusString = "";
                if (success)
                {
                    validStatusString = "valid";
                }
                else
                {
                    validStatusString = "not valid";
                }


                Console.WriteLine("Provided business ID was " + validStatusString);

                if (!success)
                {
                    using (IEnumerator<string> iterator = bIdValidator.ReasonsForDissatisfaction.GetEnumerator())
                    {
                        Console.WriteLine("Reason for failure: ");
                        while (iterator.MoveNext())
                        {
                            Console.WriteLine(iterator.Current.ToString());
                        }
                    }
                }
            }
        }
    }
}
