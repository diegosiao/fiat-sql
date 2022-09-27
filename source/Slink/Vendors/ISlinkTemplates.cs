namespace Slink.Vendors
{

    public interface ISlinkTemplates
    {
        const string DefaultNotes = @"/*
IMPORTANT! This procedure was generated and is managed by .NET Slink. DO NOT EDIT IT.
CREATION: _#creation#_
CONTENT HASH: _#hash#_
_#custom_notes#_
*/
";

        /// <summary>
        /// Placeholders:
        /// <para>_#schema#_</para>
        /// <para>_#name#_</para>
        /// <para>_#hash#_</para>
        /// <para>_#parameters#_</para>
        /// <para>_#body#_</para>
        /// </summary>
        string ProcedureTemplate { get; } 

        string DropProcedureTemplate { get; }
    }
}
