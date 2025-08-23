using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// A base for all strongly-typed field instructions.
    /// </summary>
    public class TypedFieldInstruction
    {
        public FieldInstruction Source { get; }

        protected TypedFieldInstruction(FieldInstruction source)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
        }

        public override string ToString()
        {
            // Default implementation, should be overridden by derived classes
            return Source.Instruction;
        }
    }

    /// <summary>
    /// Represents a strongly-typed REF field.
    /// </summary>
    public class RefInstruction : TypedFieldInstruction
    {
        public string BookmarkName { get; set; } = string.Empty;
        public FieldArgument? FormattingSwitch { get; set; }

        public RefInstruction(FieldInstruction source)
            : base(source)
        {
            // Constructor validates and binds the generic arguments
            if (
                source.Arguments.Count == 0
                || source.Arguments[0].Type != FieldArgumentType.Identifier
            )
            {
                throw new ArgumentException(
                    "A REF field must have a bookmark name as its first argument."
                );
            }
            BookmarkName = source.Arguments[0].Value?.ToString() ?? string.Empty;

            // Optionally find other specific arguments
            FormattingSwitch = source.Arguments.Find(arg =>
                arg.Type == FieldArgumentType.Switch
                && (arg.Value?.ToString() ?? string.Empty).StartsWith("\\*")
            );
        }
    }
}
