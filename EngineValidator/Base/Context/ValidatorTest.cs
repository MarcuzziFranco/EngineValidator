using EngineValidator.Base.Context.Rules;


namespace EngineValidator.Base.Context;

public class ValidatorTest:ValidatorBase<Test>
{
	public ValidatorTest(Test test)
	{
        //AddGeneralValidationRule(new ValidateAllField<Test>()); 
        //ExecuteGeneralRuleValidation(test);

        AddValidationClass<ValidateName>(true);
        AddValidationClass<ValidateDescription>();
        AddValidationClass<ValidateTelefono>();
        ExecuteUniqueRulesValidation(test);
	}
}
