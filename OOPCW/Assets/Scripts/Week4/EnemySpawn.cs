using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    private TileManager tileManager;

    public int row;
    public int column;
    public Vector3 enemyPosition;

    void Start()
    {
    }

    public void SpawnEnemy(TileManager tileManager, GameObject enemyPrefab)
    {
        if (tileManager != null) 
        {
            int shift = row * tileManager.boardWidth + column;
            int bitMask = 1 << shift;
            if ((tileManager.bitBoard[row, column] & bitMask) != 0)
            {
                enemyPosition = new Vector3(column, row, 0);
                Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
                print("s" + enemyPosition);
            }
            else
            {
                List<Vector2Int> walkableTiles = new List<Vector2Int>();
                for (int i = 0; i < tileManager.boardHeight; i++)
                {
                    for (int j = 0; j < tileManager.boardWidth; j++)
                    {
                        int currentShift = i * tileManager.boardWidth + j;
                        int currentBitMask = 1 << currentShift;
                        if ((tileManager.bitBoard[i, j] & currentBitMask) != 0)
                        {
                            walkableTiles.Add(new Vector2Int(j, i));
                        }
                    }
                }
                if (walkableTiles.Count > 0)
                {
                    Vector2Int randomTile = walkableTiles[Random.Range(0, walkableTiles.Count)];
                    enemyPosition = new Vector3(randomTile.x, randomTile.y, 0);
                    Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
                    print("s" + enemyPosition);
                }
                else
                {
                    Debug.Log("No walkable tiles found to spawn enemy.");
                }
            
            }
        }
        else
        {
            Debug.LogError("TileManager reference is null. Cannot spawn enemy.");
        }
    }
}

