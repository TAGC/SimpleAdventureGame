using System.Linq;

namespace experiment.Preconditions
{
    public class PossessesItem : IPrecondition
    {
        public string Item { get; set; }
        
        public bool ValidForGameState(GameState currentGameState) => currentGameState.Inventory.Items.Contains(Item);
    }
}