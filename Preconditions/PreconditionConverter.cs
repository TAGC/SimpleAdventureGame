using System;
using System.Collections.Generic;

namespace experiment.Preconditions
{
    internal sealed class PreconditionConverter : JsonDiscriminatorConverter<IPrecondition>
    {
        private static readonly IList<Type> PreconditionTypes = new[]
        {
            typeof(PossessesItem),
            typeof(DoesNotPossessItem)
        };

        public PreconditionConverter() : base(PreconditionTypes, "precondition")
        {
        }
    }
}