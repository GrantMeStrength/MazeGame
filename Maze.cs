﻿using System;


namespace Game
{
    /// <summary>
    /// Maze Game page.
    /// </summary>
    /// 

    public class Maze
    {
        // This array has a number for each tile in the maze.
        // To simplify the movement of the baddies, we use a 
        // number that contains all the directions it's possible to
        // move toward. For example, if on this tile it's possible
        // to move UP and RIGHT, we use the number 3 (1 for UP + 2 for RIGHT).
        // A value of 0 is kept for the walls.

        // We use the Binary AND operator a lot to check directions, presence of a dot.
        // It makes it easy to test for the presence of one or more values. For example,
        // if we encode the possible directions at one point with the number 9, we can
        // check with AND 2 if 2 (Left) is allowed, AND 4 (Down) etc.
        // When using Binary AND a non-Zero value means true. 

        // Maze code:
        // 0 = Wall
        // 1 = Up, 2 = Right, 4 = Down, 8 = Left
        // 16 = dot 



        Random rnd = new Random();

        private int[,] maze =
          {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,6,10,14,10,10,14,10,10,14,10,10,14,10,12,0},
            {0,5,0,5,0,0,5,0,0,5,0,0,5,0,5,0},
            {0,7,10,11,12,0,7,10,10,13,0,6,11,10,13,0},

            {0,5,0,0,5,0,5,0,0,5,0,5,0,0,5,0},
            {0,5,0,0,7,10,11,10,10,11,10,13,0,0,5,0},
            {0,5,0,0,5,0,0,0,0,0,0,5,0,0,5,0},
            {0,3,14,10,13,0,6,10,10,12,0,7,10,14,9,0},

            {0,0,5,0,5,0,5,0,0,5,0,5,0,5,0,0},
            {0,0,3,10,15,10,9,0,0,3,10,15,10,9,0,0},
            {0,0,0,0,5,0,0,0,0,0,0,5,0,0,0,0},
            {0,6,10,14,11,14,10,10,10,10,14,11,14,10,12,0},

            {0,5,0,5,0,5,0,0,0,0,5,0,5,0,5,0},
            {0,5,0,5,0,5,0,0,0,0,5,0,5,0,5,0},
            {0,3,10,11,10,11,10,10,10,10,11,10,11,10,9,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            };

        public Maze()
        {
            // Add dots to the maze for the player to collect.
            // We do this by adding 16 to and non-zero value already present 
            // in the maze. There are 122 dots in the current maze.

            for (int y = 0; y < 16; y++)
                for (int x = 0; x < 16; x++)
                {
                    int tile = maze[y, x];

                    if (tile != 0)
                    {
                        maze[y, x] = tile + 16;
                    }
                }
        }
    
        public int getTile(int a, int b)
        {
            return maze[a, b];
        }

        public void setTile(int a, int b, int newTile)
        {
            maze[a, b] = newTile;
        }

        // This code provides our baddies with a new direction value, hopefully one that prevents them from
        // getting stuck in an infinite loop. This is something that needs improvement - and also is where
        // you could put code that makes the baddies specifically follow the player.

        private int[] sequence = { 1, 2, 4, 8, 4, 2, 1, 1, 2, 2, 4, 4, 8, 8, 1, 2, 4, 8, 8, 4, 4, 2, 2, 1, 1, 2, 2, 4, 4, 8, 2, 4, 8, 4, 1, 2 };
        private int sequenceCounter = 0;

        public int NextDirection()
        {
            sequenceCounter = sequenceCounter + 1;
            if (sequenceCounter >= sequence.Length) sequenceCounter = rnd.Next(sequence.Length);
            return sequence[sequenceCounter];
        }
    }
}
