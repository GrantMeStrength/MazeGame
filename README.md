# MazeGame

## A Win2D based game skeleton for Windows 10


![Maze Game](/Assets/gamegrid.png)

This is a simple maze chase / eat the dots game that demonstrates using Win2D to display and move images.
The game screen is a 1024 by 1024 canvas object. A single bitmap displays a maze image, but really the maze
is a 16 by 16 array of integers with each element defining the possible directions the player or baddie can 
move in.

The images move smoothly until they are centered in a tile, and only then can they change direction.

No "game over" or scoring events are present - that's up to you!

