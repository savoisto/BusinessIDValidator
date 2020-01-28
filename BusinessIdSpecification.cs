using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BusinessIdSpecification
{
    public class BusinessIdSpecification : ISpecification<string>
    {
        public IEnumerable<string> ReasonsForDissatisfaction => _listOfFails;
        private List<string> _listOfFails = new List<string>();

        static void Main()
        {
            

        }

        /// <summary>
        /// Check if string is in business ID format. 7 Digits followed by a dash and a control mark. 
        /// Link to YTJ, business information system specifications of a <a href="https://www.ytj.fi/en/index/businessid.html">Business ID</a>.
        /// Matching is done with regex. ReasonsForDissatisfaction will contain reasons for failure
        /// </summary>
        /// <param name="bId">String to check</param>
        /// <returns></returns>
        public bool IsSatisfiedBy(string bId)
        {

            if(bId == null)
            {
                _listOfFails.Add("No value provided");
                return false;
            }

            //Regex check
            var match = Regex.Match(bId, @"^[\d]{7}-[\d]$");

            //TODO: Reason for dissatisfaction
            return match.Success;
        }
    }
}
