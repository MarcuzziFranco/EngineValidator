using EngineValidator;
using EngineValidator.Base.Context;

Console.WriteLine("RUNNING");
Test test = new Test("Test", "", "12342121232");

ValidatorTest validatorTest = new(test);

if (validatorTest.GetResultValidationStatus())
    Console.WriteLine("Todo OK");
else
    validatorTest.ListErrorsPrint();
