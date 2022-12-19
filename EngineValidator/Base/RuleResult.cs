namespace EngineValidator.Base;

public class RuleResult
{
    private bool isValid;
    private Dictionary<string, string> errors;
    private Dictionary<string, IfResult> errorsByIf;

    public RuleResult()
    {
        errors = new Dictionary<string, string>();
        errorsByIf = new Dictionary<string, IfResult>();
        isValid = true;
    }

    public void setIsValid(bool status)
    {
        isValid = status;
    }

    public void setError(string code, string errorMessage)
    {
        isValid = false;
        setErrorMessage(code, errorMessage);
    }

    public void setErrorByIf(string code,string errorMssage,bool statusByIf)
    {
        setErrorMessageByIf(code, errorMssage, statusByIf);
    }

    public void setErrorByIf(string code, string errorMssage)
    {
        setErrorMessageByIf(code, errorMssage);
    }

    public bool getIsValid() { return isValid; }

    private void setErrorMessage(string code, string errorMessage)
    {
        if (!IsHashCodeExist(code)) errors[code] = errorMessage;
        else ErrorExceptionHashCode(code);
    }

    private void setErrorMessageByIf(string code, string errorMessage)
    {
        if (!IsHashCodeExist(code))
            errorsByIf[code] = new IfResult(errorMessage);
        else ErrorExceptionHashCode(code);
    }

    private void setErrorMessageByIf(string code, string errorMessage,bool status)
    {
        if (!IsHashCodeExist(code))
            errorsByIf[code] = new IfResult(errorMessage, status);
        else ErrorExceptionHashCode(code);
    }

    private bool IsHashCodeExist(string code)
    {
        return errors.ContainsKey(code);
    }

    private Exception ErrorExceptionHashCode(string code)
    {
       return new Exception("The error code " + code + " already exists. You are trying to register 2 or more errors with the same code");
    }

    public string GetRuleMessage()
    {
        string message = string.Empty;
        foreach (var ruleMessage in errors)
        {
            message += ruleMessage.Value;
        }

        return message;
    }
    public List<string> GetListRuleMessages()
    {
        List<string> messages = new List<string>();
        foreach (var ruleMessage in errors)
        {
            if(!UtilsValidations.stringEmpty(ruleMessage.Value))
                messages.Add(ruleMessage.Value);
        }
        return messages;
    }
}

public class IfResult
{
    private string message { get;}
    private bool isValid { get;}

    public IfResult (string message)
    {
        this.message = message;
    }
    public IfResult(string message, bool isValid)
    {
        this.message = message;
        this.isValid = isValid;
    }
}