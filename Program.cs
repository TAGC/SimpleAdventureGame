
using System;

namespace experiment
{
    class Program
    {
        static void Main(string[] args)
        {
            var setup = CreateGameSetup();
            var gameLoop = new GameLoop(setup);

            while (!gameLoop.IsGameOver)
            {
                gameLoop.Next();
            }
        }

        /// <remarks>
        /// This is hardcoded here just as an example.
        /// <para></para>
        /// A better way to do it would be to define all scenarios and choices as JSON and deserialise
        /// them during application startup. That way you cleanly separate code and data, and don't need
        /// to modify existing code and recompile just to expand the game.
        /// <para></para>
        /// I've implemented JSON deserialisation support but haven't tested it out.
        /// </remarks>
        static GameSetup CreateGameSetup()
        {
            const string StartVillage = "START_VILLAGE";
            const string Ded = "DED";
            const string Escaped = "ESCAPED";

            var scenarios = new[]
            {
                new Scenario(StartVillage, "You are in a village or some shit."),
                Scenario.CreateEndgame(Ded, "You're dead!"),
                Scenario.CreateEndgame(Escaped, "You have escaped the scary village!"),
            };

            var choices = new[]
            {
                new Choice(StartVillage, Ded, "You walk north for a bit. Oh no a skeleton found you."),
                new Choice(StartVillage, Escaped, "You walk south for a bit. Neat, no trouble at all.")
            };

            return new GameSetup(scenarios, choices, StartVillage);
        }
    }
}