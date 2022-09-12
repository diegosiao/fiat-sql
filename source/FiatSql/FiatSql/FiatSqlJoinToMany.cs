using System;

namespace Slink
{
    public class SlinkJoinToManyAttribute : Attribute
    {
        public SlinkJoinToManyAttribute(Type relationEntity, string fromColumn, string onColumn, bool leftJoin = false)
        {

        }
    }
}
