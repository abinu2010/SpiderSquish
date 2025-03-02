using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager2 : MonoBehaviour
{
    public EnemySpawn enemySpawn;
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
                bitBoard[i, j] = randomBit;
                Vector3 tilePosition = new Vector3(j, -i, 0); 
                GameObject tilePrefab = randomBit == 1 ? unwalkable : walkable;               
                GameObject tileInstance = Instantiate(tilePrefab, tilePosition, Quaternion.identity);
                tileInstance.transform.SetParent(transform);
            }
        }
    }
}

