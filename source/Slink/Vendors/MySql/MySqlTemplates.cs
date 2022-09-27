using Slink.Vendors;

namespace FiatSql.Vendors.MySql
{
    internal class MySqlTemplates : ISlinkTemplates
    {
        public string ProcedureTemplate => @"
CREATE PROCEDURE _#schema#_._#name#_(
_#parameters#_
)
BEGIN
_#body#_
END;
";

        public string DropProcedureTemplate => "DROP PROCEDURE IF EXISTS _#schema#_._#name#_;";
    }
}
