using System;
using System.Collections.Generic;
using BusinessIdSpecification;

namespace ConsoleAppForBISpecification
{
    class Program
    {
        /// <summary>
        /// Console application intended to use and test BusinessIDSpecification dll
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            bool cont = true;
            //Continue untill exit with 0
            while (cont)
            {
                Console.WriteLine("Enter Business ID to validate or enter 0 to exit the app: ");
                var bId = Console.ReadLine();

                //Check if ready to exit
                if(bId == "0")
                {
                    cont = false;
                    Console.Write("Exitting application");
                    Environment.Exit(0);
                }

                //Initialize class and validate given string
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

                //If not valid BID, print out reasons why
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
