using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace experiment
{
    public class Scenario
    {
        [JsonConstructor]
        public Scenario(string id, string description, bool endgame = false)
        {
            Id = id ?? throw new ArgumentNullException(id);
            Description = description ?? throw new ArgumentNullException(description);
            Endgame = endgame;
        }

        public string Id { get; }
        public string Description { get; }
        public bool Endgame { get; }

        public static Scenario CreateEndgame(string id, string description) => new Scenario(id, description, true);
    }
}