using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace experiment
{
    public class GameLoop
    {
        private readonly IList<Scenario> _scenarios;
        private readonly IList<Choice> _choices;

        private Scenario _currentScenario;

        public GameLoop(GameSetup setup)
        {
            if (setup == null)
            {
                throw new ArgumentNullException(nameof(setup));
            }

            _scenarios = setup.Scenarios.ToList();
            _choices = setup.Choices.ToList();
            _currentScenario = ScenarioLookup[setup.InitialScenarioId];
        }

        public bool IsGameOver => _currentScenario.Endgame;

        private IDictionary<string, Scenario> ScenarioLookup =>  _scenarios.ToDictionary(it => it.Id);

        public void Next()
        {
            AssertGameNotOver();

            Console.WriteLine(_currentScenario.Description);

            var availableChoices = from choice in _choices
                                   where choice.StartScenarioId == _currentScenario.Id
                                   select choice;

            Debug.Assert(availableChoices.Count() <= 26, "Really shouldn't be this many choices");

            var userOptions = Enumerable
                .Range('a', 26)
                .Select(id => ((char)id).ToString())
                .Zip(availableChoices, ValueTuple.Create)
                .ToDictionary(pair => pair.Item1, pair => pair.Item2);

            HandleChoice(GetUserChoice(userOptions));
        }

        private static Choice GetUserChoice(Dictionary<string, Choice> userOptions)
        {
            var choiceIds = userOptions.Select(it => it.Key);
            Console.WriteLine($"Pick a choice between {choiceIds.First()} and {choiceIds.Last()}");

            string selectedChoiceId = null;
            while (!TryQueryUserForChoice(choiceIds, out selectedChoiceId))
            {
                Console.WriteLine("That is not a valid action. Please choose again.\n");
            }

            return userOptions[selectedChoiceId];
        }

        private static bool TryQueryUserForChoice(IEnumerable<string> choiceIds, out string selectedChoiceId)
        {
            var match = Regex.Match(Console.ReadLine().ToLowerInvariant(), "[a-z]");

            if (!match.Success || !choiceIds.Contains(match.Value))
            {
                selectedChoiceId = null;
                return false;
            }

            selectedChoiceId = match.Value;
            return true;
        }

        private void HandleChoice(Choice choice)
        {
            Console.WriteLine(choice.Description);
            _currentScenario = ScenarioLookup[choice.EndScenarioId];

            if (IsGameOver)
            {
                HandleGameOver();
            }
        }

        private void HandleGameOver()
        {
            Console.WriteLine(_currentScenario.Description);
            Console.WriteLine("Thanks for playing!");
        }

        private void AssertGameNotOver()
        {
            if (IsGameOver)
            {
                throw new InvalidOperationException("The game is over");
            }
        }
    }
}