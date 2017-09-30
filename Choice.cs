using Newtonsoft.Json;

namespace experiment
{
    public class Choice
    {
        [JsonConstructor]
        public Choice(string startScenarioId, string endScenarioId, string description)
        {
            StartScenarioId = startScenarioId ?? throw new System.ArgumentNullException(nameof(startScenarioId));
            EndScenarioId = endScenarioId ?? throw new System.ArgumentNullException(nameof(endScenarioId));
            Description = description ?? throw new System.ArgumentNullException(nameof(description));
        }

        public string StartScenarioId { get; }
        public string EndScenarioId { get; }
        public string Description { get; }
    }
}