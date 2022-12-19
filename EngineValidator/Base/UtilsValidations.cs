using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EngineValidator.Base
{
    public class UtilsValidations
    {
        public readonly static Func<object, bool> isNull = ob => ob is null;
        public readonly static Func<dynamic, Type, bool> correctType = (ob, type) => ob.GetType() == type;
        public readonly static Func<string, bool> stringEmpty = ob => ob == "";
        public readonly static Func<string, string, bool> StringFormatAccordingToRegex = (ob, pattern) => Regex.Match(ob, pattern).Success;
    }
}
