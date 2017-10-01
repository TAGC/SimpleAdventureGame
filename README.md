Build Da Game
---

`git clone https://github.com/TAGC/SimpleAdventureGame && cd SimpleAdventureGame && dotnet build`

Play Da Game
---

(In project directory)

`dotnet run`

Expand Da Game
---

I made it so that code and data have a clean separation; all the scenarios and choices and stuff are defined in JSON, and you can make the game more interesting by simply editing `game.json` without having to modify any code/recompile anything.

Example of a game session
---

```
You are in a village or some shit.
Pick a choice between a and b
foo
That is not a valid action. Please choose again.

a
You walk north for a bit. Oh no a skeleton found you.
You're dead!
Thanks for playing!
```
