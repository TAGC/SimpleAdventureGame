using Newtonsoft.Json;

namespace experiment.Actions
{
    [JsonConverter(typeof(ActionConverter))]
    public interface IAction
    {
        GameState UpdateGameState(GameState currentGameState);
    }
}