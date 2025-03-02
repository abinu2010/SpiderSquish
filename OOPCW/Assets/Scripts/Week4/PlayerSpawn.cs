using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public bool playerSpawned = false;
    public Vector2Int playerPosition;

    public void SpawnPlayer(TileManager tileManager, GameObject playerPrefab)
    {
        Vector2Int playerSpawnPosition = FindValidWalkableTilePosition(tileManager);
        if (playerSpawnPosition != Vector2Int.zero)
        {
            Vector3 playerSpawnWorldPosition = new Vector3(playerSpawnPosition.x, playerSpawnPosition.y, 0);
            playerPosition.x = playerSpawnPosition.x;
            playerPosition.y = playerSpawnPosition.y;
            playerSpawned = true;
            Instantiate(playerPrefab, playerSpawnWorldPosition, Quaternion.identity);
            tileManager.bitBoard[playerSpawnPosition.y, playerSpawnPosition.x] |= 1;
        }
        else
        {
            Debug.LogError("No valid walkable tile found to spawn player.");
        }
    }

    Vector2Int FindValidWalkableTilePosition(TileManager tileManager)
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
            Debug.Log("Randomly selected walkable tile: " + randomTile);
            return randomTile;
        }
        else
        {
            Debug.Log("No walkable tiles found to spawn player.");
            return Vector2Int.zero;
        }
    }
}
