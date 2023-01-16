
namespace EngineValidator.Base.Context.Rules;

public class ValidateName : AbstractUniqueValidationRule<Test>
{
    public ValidateName(){}

    public override RuleResult EvaluateUniqueValidationRule(Test instance)
    {
        return ValidationNameExistAndString(instance);
    }


    private RuleResult ValidationNameExistAndString(Test data)
    {        
        if (UtilsValidations.isNull(data.name))
            result.setError("CODE_1", "Error el nombre no puede ser nulo");
        if (UtilsValidations.stringEmpty(data.name))
            result.setError("CODE_2", "Error el nombre no puede estar vacio");
        if (UtilsValidations.stringEmpty(data.name))
            result.setError("CODE_3", "Error no se valido correctamente este campo");
        return result;
    }
}
