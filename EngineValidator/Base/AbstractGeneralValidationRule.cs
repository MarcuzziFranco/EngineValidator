using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineValidator.Base;

public abstract class AbstractGeneralValidationRule<T>
{
    protected RuleResult result = new();
    private bool exclusive;
    public AbstractGeneralValidationRule() { }
    public AbstractGeneralValidationRule(bool exclusive)
    {
        this.exclusive = exclusive;
    }

    public bool IsExclusive() { return exclusive; }
    public abstract RuleResult EvaluatelGeneralValidationRule(dynamic instance);
}
