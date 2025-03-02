using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public EnemySpawn enemySpawn;
    public PlayerController playerController;

    public GameObject walkable;
    public GameObject unwalkable;

    public int boardHeight;
    public int boardWidth;
    public int[,] bitBoard;

    public void MakeBoard()
    {
        bitBoard = new int[boardHeight, boardWidth];

        for (int i = 0; i < boardHeight; i++)
        {
            for (int j = 0; j < boardWidth; j++)
            {
                int randomBit = Random.value < 0.5f ? 0 : 1;
                int shift = i * boardWidth + j;
                int shiftedBit = randomBit << shift;
                bitBoard[i, j] |= shiftedBit;
                Vector3 tilePosition = new Vector3(j, i, 0);
                GameObject tilePrefab = randomBit == 1 ? walkable : unwalkable;
                Instantiate(tilePrefab, tilePosition, Quaternion.identity);
            }
        }
    }
}

