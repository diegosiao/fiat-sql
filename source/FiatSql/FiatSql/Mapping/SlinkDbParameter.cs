using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slink.Mapping
{
    public abstract class SlinkDbParameterAttribute : Attribute
    {
    }

    public class SlinkDbParameterOutAttribute : SlinkDbParameterAttribute { }

    public class SlinkReadOnlyAttribute : SlinkDbParameterAttribute { }
}
