using System;
using System.Collections.Generic;
using BusinessIdSpecification;

namespace ConsoleAppForBISpecification
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Business ID to validate: ");
            var bId = Console.ReadLine();
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

            if(!success)
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
