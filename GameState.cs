using System.Linq;

namespace experiment
{
    public class GameState
    {
        public GameState()
        {
            Inventory = new Inventory();
        }

        public Inventory Inventory { get; }

        public GameState Copy()
        {
            var copy = new GameState();
            Inventory.Items.ToList().ForEach(copy.Inventory.StoreItem);

            return copy;
        }
    }
}