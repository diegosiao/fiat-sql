using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FiatSql
{
    public abstract class FiatSqlProcedure
    {
        private string _sql;
        public string Sql
        {
            get
            {
                _sql ??= BuildSql();
                return _sql;
            }
            private set
            {
                _sql = value;
            }
        }

        private string _hash;

        public string Hash
        {
            get { return _hash; }
            private set { _hash = value; }
        }

        internal StringBuilder BodySql { get; set; }

        public List<FiatDbParameter> Parameters { get; private set; }

        private uint currentIdentation = 0;

        private void IncreaseIdentation(uint identation = 2)
        {
            currentIdentation += Options.DefaultIdentation ?? identation;
        }

        private void DecreaseIdentation(uint identation = 2)
        {
            currentIdentation -=
                (currentIdentation - (Options.DefaultIdentation ?? identation) >= 0 ? Options.DefaultIdentation ?? identation : 0);
        }

        private string GetIdentation(uint? identation = null)
        {
            var ident = new StringBuilder();
            for (int i = 0; i < (identation ?? currentIdentation); i++)
                ident.Append(" ");

            return ident.ToString();
        }

        protected readonly FiatSqlConfigOptions Options;

        public FiatSqlProcedure(FiatSqlConfigOptions options = null)
        {
            Options = options ?? FiatSql.Options;
            Parameters = new List<FiatDbParameter>();
            Sql = string.Empty;
            BodySql = new StringBuilder();

            IncreaseIdentation();
        }

        protected void Execute<TEntity>(FiatCrudOperation<TEntity> operation)
        {
            Parameters.AddRange(operation.Parameters);

            BodySql.AppendLine();

            var operationLines = new List<string>(operation.Sql.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
            var ident = GetIdentation();
            foreach (var line in operationLines)
                BodySql.AppendLine($"{ident}{line}");
        }

        protected void If(string sqlCondition, Action action)
        {
            IncreaseIdentation();

            BodySql.AppendLine(string.Empty);

            DecreaseIdentation();
        }

        protected void Declare<T>(string name, object initialValue = null)
        {

        }

        protected void SelectInto(string sqlSelect, params object[] variables)
        {
            BodySql.AppendLine(string.Empty);


        }

        protected void Return()
        {
            BodySql.AppendLine(string.Empty);
            BodySql.AppendLine("RETURN;");
        }

        public string BuildSql()
        {
            _sql = Options.Templates.ProcedureTemplate
                .Replace("_#schema#_", "public")
                .Replace("_#name#_", GetType().Name.ToLower())
                .Replace("_#parameters#_", GetParametersSql().ToString())
                .Replace("_#body#_", BodySql.ToString());

            _hash = Convert.ToHexString(SHA1.HashData(Encoding.UTF8.GetBytes(_sql)));

            _sql = _sql.Replace("_#hash#_", _hash);

            return _sql;
        }

        public string GetParametersSql()
        {
            return string.Join(",\r\n", Options.Writer.ProcedureParameters(Parameters).Select(l => $"{GetIdentation(2)}{l}"));
        }

        public void Call(FiatSqlConfigOptions options = null)
        {
            var _options = options ?? FiatSql.Options;

            var dynamicParameters = new DynamicParameters();

            // Called to update dbtypes
            _ = Options.Writer.ProcedureParameters(Parameters);

            Parameters.ForEach((p) => dynamicParameters.Add(p.ParameterName, p.Value, p.DbType, p.Direction));

            using (var connection = _options.ConnectionFactory())
            {
                connection.Execute(GetType().Name.ToLower(), param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
