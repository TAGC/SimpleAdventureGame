using System;
using System.Collections.Generic;

namespace experiment.Actions
{
    internal sealed class ActionConverter : JsonDiscriminatorConverter<IAction>
    {
        private static readonly IList<Type> ActionTypes = new[]
        {
            typeof(StoreItem)
        };

        public ActionConverter() : base(ActionTypes, "action")
        {
        }
    }
}