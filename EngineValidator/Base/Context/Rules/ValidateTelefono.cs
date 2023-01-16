using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineValidator.Base.Context.Rules;

public class ValidateTelefono : AbstractUniqueValidationRule<Test>
{
    public override RuleResult EvaluateUniqueValidationRule(Test instance)
    {
        if(instance.telefono.Length < 14)
            result.setError("Code", "Error telefono cantidad de numero no valida.");
        
        return result;
        
    }
}
