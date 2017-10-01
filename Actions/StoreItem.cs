using System;

namespace experiment.Actions
{
    public class StoreItem : IAction
    {
        public string Item { get; set; }

        public GameState UpdateGameState(GameState currentGameState)
        {
            var newGameState = currentGameState.Copy();
            newGameState.Inventory.StoreItem(Item);
            Console.WriteLine($"[ACQUIRED] {Item}");

            return newGameState;
        }
    }
}