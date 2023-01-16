using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineValidator;

public class Test
{
    public string? name { get; set; }
    public string? description { get; set; }
    public string? telefono { get; set; }

    public Test(string name, string description, string telefono)
    {
        this.name = name;
        this.description = description;
        this.telefono = telefono;
    }
}
