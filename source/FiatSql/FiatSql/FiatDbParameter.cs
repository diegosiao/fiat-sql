using System;
using System.Data;
using System.Data.Common;
using System.Reflection;

namespace Slink
{
    public class FiatDbParameter : DbParameter
    {
        public override DbType DbType { get; set; }
        public PropertyInfo PropertyInfo { get; set; }
        public override ParameterDirection Direction { get; set; }
        public override bool IsNullable { get; set; }
        public override string ParameterName { get; set; }
        public override int Size { get; set; }
        public override string SourceColumn { get; set; }
        public override bool SourceColumnNullMapping { get; set; }
        public override object Value { get; set; }

        public FiatDbParameter()
        {

        }

        public FiatDbParameter(string parameterName, object value)
        {
            ParameterName = parameterName;
            Value = value;
        }

        public override void ResetDbType()
        {
            throw new NotImplementedException();
        }
    }
}
