// See https://aka.ms/new-console-template for more information
using EngineValidator;
using EngineValidator.Base.Context;

Console.WriteLine("RUNNING");
Test test = new Test();
test.name = "";

ValidatorTest validatorTest = new(test);

if (validatorTest.GetResultValidationStatus())
    Console.WriteLine("Todo OK");
else
    validatorTest.ListErrorsPrint();
