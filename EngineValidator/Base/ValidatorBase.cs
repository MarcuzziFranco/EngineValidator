using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace EngineValidator.Base;

public abstract class ValidatorBase<T>
{
    private List<AbstractUniqueValidationRule<T>> CollectionOfUniqueValidations;
    private List<AbstractGeneralValidationRule<T>> CollectionOfGeneralRulesValidations;
    private readonly List<RuleResult> ruleResults = new();

    public ValidatorBase()
    {
        CollectionOfUniqueValidations = new List<AbstractUniqueValidationRule<T>>();
        CollectionOfGeneralRulesValidations = new List<AbstractGeneralValidationRule<T>>();
        ruleResults = new List<RuleResult>();
    }
   
    public void AddValidationClass<ClassValidate>(bool exclusive=false)
       where ClassValidate : AbstractUniqueValidationRule<T>, new()
    {
        AbstractUniqueValidationRule<T> classValidate = new ClassValidate();
        classValidate.SetExclusive(exclusive);
        AddUniqueValidationRule(classValidate);
    }

    private void AddUniqueValidationRule(AbstractUniqueValidationRule<T> validationUniqueRule)
    {
        CollectionOfUniqueValidations.Add(validationUniqueRule);
    }

    protected void ExecuteUniqueRulesValidation(T instance)
    {
        foreach (var rule in CollectionOfUniqueValidations)
        {
            ruleResults.Add(rule.EvaluateUniqueValidationRule(instance));
            if(rule.IsExclusive())
                if (!ruleResults.Last().getIsValid()) break;            
        }
    }

    protected void AddGeneralValidationRule(AbstractGeneralValidationRule<T> validationGeneralRule)
    {
        CollectionOfGeneralRulesValidations.Add(validationGeneralRule);
    }

    protected void ExecuteGeneralRuleValidation(T instance)
    {
        PropertyInfo[] fields = instance.GetType().GetProperties();

        foreach (var rule in CollectionOfGeneralRulesValidations)
        {
            for (int i = 0; i < fields.Length; i++)
            {
                Console.WriteLine(fields[i]);
                dynamic field = fields[i];
                rule.EvaluatelGeneralValidationRule(field);
            }
        }
    }


    //GETS STATUS VALIDATOR

    public PackageRuleResult GetResultValidation()
    {
        PackageRuleResult pakageRuleResult = new PackageRuleResult();
        pakageRuleResult.isValid = ruleResults.All(rule => rule.getIsValid());

        ruleResults.ForEach(rule => {
            string ruleMessage = rule.GetRuleMessage();
            if (!UtilsValidations.stringEmpty(ruleMessage))
                pakageRuleResult.errors.Add(rule.GetRuleMessage());
        });

        return pakageRuleResult;
    }

    public bool GetResultValidationStatus()
    {
        bool result = false;
        result = ruleResults.All(rule => rule.getIsValid());
        return result;
    }

    public List<string> GetListErrors()
    {
        List<string> result = new();
        ruleResults.ForEach(rule =>
        {
            result.AddRange(rule.GetListRuleMessages());
        });
        return result;
    }

    public void ListErrorsPrint()
    {
        List<string> result = new();
        result = GetListErrors();
        result.ForEach(error => Console.WriteLine(error));
    }
}
