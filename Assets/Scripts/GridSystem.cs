using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class GridSystem
{
    //It's technically not a grid, but measurements, but whatever, it's a game jam
    public static int xMax { get; private set; }
    public static int yMax { get; private set; }

    public static float squareSize { get; private set; }

    public static bool[,] availability;

    public static void InitializeGrid(int x, int y, float size)
    {
        xMax = x;
        yMax = y;
        squareSize = size;
    }

    public static void DrawGizmos()
    {
        Gizmos.color = Color.green;
        for(float i = -xMax/2 *squareSize; i < xMax/2 * squareSize; i+= squareSize)
        {
            for (float k = squareSize/2; k < yMax * squareSize; k += squareSize)
            {
                Gizmos.DrawWireCube(new Vector2(i, k), new Vector3(squareSize,squareSize,squareSize));
            }
        }
    }
}
