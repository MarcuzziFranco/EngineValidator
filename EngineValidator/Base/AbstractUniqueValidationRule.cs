using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineValidator.Base;

public abstract class AbstractUniqueValidationRule<T>
{
    protected RuleResult result = new RuleResult();
    private bool exclusive;
    public void SetExclusive(bool value) { exclusive = value;}
    public bool IsExclusive() { return exclusive; }
    public abstract RuleResult EvaluateUniqueValidationRule(T instance);
}
