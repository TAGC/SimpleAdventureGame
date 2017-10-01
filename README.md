Build Da Game
===

`git clone https://github.com/TAGC/SimpleAdventureGame && cd SimpleAdventureGame && dotnet build`

Play Da Game
===

(In project directory)

`dotnet run`

Expand Da Game
===

I made it so that code and data have a clean separation; all the scenarios and choices and stuff are defined in JSON, and you can make the game more interesting by simply editing `game.json` without having to modify any code/recompile anything.

Example game sessions
===

Some playthroughs to demonstrate.

Quick death
---

```
You are in a village or some shit.
Pick a choice between a and c
b
You walk north for a bit. Oh no a skeleton found you. Unarmed as you are, he easily overpowers you.
You're dead!
Thanks for playing!
```

Finding a useful tool
---


```
You are in a village or some shit.
Pick a choice between a and c
a
You discover a shovel on the ground nearby. You pick it up.
[ACQUIRED] shovel
You are in a village or some shit.
Pick a choice between a and b
a
You walk north for a bit. Oh no a skeleton found you. You whack him with the shovel, leaving him disoriented and giving you time
to escape.
You have escaped the scary village!
Thanks for playing!
```
