using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BusinessIdSpecification
{
    public class BusinessIdSpecification : ISpecification<string>
    {
        /// <summary>
        /// Contains List<string> of reasons IsSatisfiedBy failed
        /// </summary>
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
            //If no value is provided, immediately fail before any other checks
            if(bId == null)
            {
                _listOfFails.Add("No value provided");
                return false;
            }

            //Regex check
            var match = Regex.Match(bId, @"^[\d]{7}-[\d]$");

            //Begin finding reason for failure
            if(!match.Success)
            {
                CheckStringForFailure(bId);
            }

            return match.Success;
        }

        /// <summary>
        /// Checks if the input string follows the business information system specifications of a <a href="https://www.ytj.fi/en/index/businessid.html">Business ID</a>.
        /// </summary>
        /// <param name="bId">Business ID</param>
        private void CheckStringForFailure(string bId)
        {
            //Value too long
            if (bId.Length > 9)
            {
                _listOfFails.Add("Value too long");
            }
            //Value too short
            else if (bId.Length < 9)
            {
                _listOfFails.Add("Value too short");
            }
            //Value right length, but something else is wrong
            else if (bId.Length == 9)
            {
                //Is the dash missing
                if (!bId.Contains("-"))
                {
                    _listOfFails.Add("No dash provided");
                }
                else
                {
                    //Check if string contains only digits, besides the mandatory dash
                    string replacedStr = Regex.Replace(bId, "-", "");
                    if (!int.TryParse(replacedStr, out int n))
                    {
                        _listOfFails.Add("ID or the control mark contains non numeric values");
                    }

                    //Check if the seven digit dash control mark format is correct or not
                    string[] splitbId = bId.Split('-');
                    if(splitbId[0].Length != 7 || splitbId[1].Length != 1)
                    {
                        _listOfFails.Add("Value formatting is incorrect");
                    }
                }
            }

            if(_listOfFails.Count == 0)
            {
                _listOfFails.Add("Value validation failed for an unknown reason");
            }
        }
    }
}
