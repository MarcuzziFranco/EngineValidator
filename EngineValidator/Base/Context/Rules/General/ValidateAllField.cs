using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineValidator.Base.Context.Rules.General;

public class ValidateAllField<T> : AbstractGeneralValidationRule<T>
{
    public override RuleResult EvaluatelGeneralValidationRule(dynamic instance)
    {
        if (instance == null)
            result.setError("Code_1","existen campos nulos");
        return result;
    }
}
