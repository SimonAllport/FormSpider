using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CloudFish.FormSpider
{
    public class Validation
    {

        public Boolean ValidateControl(string ControlType, string ControlName)
        {
            Boolean Result = false;
            LookUpData lookupdata = new LookUpData();
            string pattern = lookupdata.GetRegularExpression(ControlType);
            Result = pattern != string.Empty ? Validate(pattern, ControlName) : false;
            return Result;

        }

        private Boolean Validate(string pattern, string input)
        {
            Boolean result = false;

            Regex rgx = new Regex(pattern, RegexOptions.None);
            Boolean success = rgx.Match(input).Success;

            return result;
        
        }


    }
}
