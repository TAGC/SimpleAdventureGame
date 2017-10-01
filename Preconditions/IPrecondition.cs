using Newtonsoft.Json;

namespace experiment.Preconditions
{
    [JsonConverter(typeof(PreconditionConverter))]
    public interface IPrecondition
    {
        bool ValidForGameState(GameState currentGameState);
    }
}