using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineValidator.Base
{
    public class PackageRuleResult
    {
        public bool isValid;
        public List<string> errors;

        public PackageRuleResult()
        {
            errors = new List<string>();
        }
    }
}
