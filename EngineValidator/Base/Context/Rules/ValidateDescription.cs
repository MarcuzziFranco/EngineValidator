using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineValidator.Base.Context.Rules;

public class ValidateDescription : AbstractUniqueValidationRule<Test>
{
    public override RuleResult EvaluateUniqueValidationRule(Test instance)
    {
        return ValidationDescriptionExistAndString(instance.description);
    }

    public RuleResult ValidationDescriptionExistAndString(string descripction)
    {
        if (UtilsValidations.isNull(descripction))
            result.setError("CODE_1", "Error la descripction no puede ser nulo");
        if (UtilsValidations.stringEmpty(descripction))
            result.setError("CODE_2", "Error la descripction no puede estar vacio");
        if (UtilsValidations.stringEmpty(descripction))
            result.setError("CODE_3", "Error no se valido correctamente este campo");
        return result;
    }

   
}
