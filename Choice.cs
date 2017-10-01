using System.Collections.Generic;
using System.Linq;
using experiment.Actions;
using experiment.Preconditions;
using Newtonsoft.Json;

namespace experiment
{
    public class Choice
    {
        [JsonConstructor]
        public Choice(
            string startScenarioId,
            string endScenarioId,
            string description,
            IEnumerable<IAction> actions = null,
            IEnumerable<IPrecondition> preconditions = null)
        {
            StartScenarioId = startScenarioId ?? throw new System.ArgumentNullException(nameof(startScenarioId));
            EndScenarioId = endScenarioId ?? throw new System.ArgumentNullException(nameof(endScenarioId));
            Description = description ?? throw new System.ArgumentNullException(nameof(description));
            Actions = actions ?? Enumerable.Empty<IAction>();
            Preconditions = preconditions ?? Enumerable.Empty<IPrecondition>();
        }

        public string StartScenarioId { get; }
        public string EndScenarioId { get; }
        public string Description { get; }
        public IEnumerable<IAction> Actions { get; }
        public IEnumerable<IPrecondition> Preconditions { get; }
    }
}