using System.Collections.Generic;
using System.Linq;

namespace experiment
{
    public class GameSetup
    {
        public GameSetup(IEnumerable<Scenario> scenarios, IEnumerable<Choice> choices, string initialScenarioId)
        {
            if (scenarios == null)
            {
                throw new System.ArgumentNullException(nameof(scenarios));
            }

            if (choices == null)
            {
                throw new System.ArgumentNullException(nameof(choices));
            }

            Scenarios = scenarios.ToList();
            Choices = choices.ToList();
            InitialScenarioId = initialScenarioId ?? throw new System.ArgumentNullException(nameof(initialScenarioId));
        }

        public IList<Scenario> Scenarios { get; }
        public IList<Choice> Choices { get; }
        public string InitialScenarioId { get; }
    }
}