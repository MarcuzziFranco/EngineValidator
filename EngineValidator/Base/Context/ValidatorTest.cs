using EngineValidator.Base.Context.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineValidator.Base.Context;

public class ValidatorTest:ValidatorBase<Test>
{
	public ValidatorTest(Test test)
	{
        AddUniqueValidationRule(new ValidateName());
        AddUniqueValidationRule(new ValidateDescription());
        ExecuteUniqueRulesValidation(test);
	}
}
