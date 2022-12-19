using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
    protected void AddUniqueValidationRule(AbstractUniqueValidationRule<T> validationRule)
    {
        CollectionOfUniqueValidations.Add(validationRule);
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



    protected void ExecuteGenetalRuleValidation(T instance)
    {
        FieldInfo[] fields = typeof(T).GetFields();

        

        foreach(var rule in CollectionOfGeneralRulesValidations)
        {

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
