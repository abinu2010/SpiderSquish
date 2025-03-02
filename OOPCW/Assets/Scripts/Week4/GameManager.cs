using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TileManager tileManager;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public Component PlayerSpawn;

    void Start()
    {
        SpawnBoard();
        SpawnEnemy();
        SpawnPlayer();
    }

    

    void SpawnBoard()
    {
        tileManager.MakeBoard();
    }

    void SpawnPlayer()
    {
        PlayerSpawn playerSpawn = gameObject.AddComponent<PlayerSpawn>();
        try
        {
            playerSpawn.SpawnPlayer(this.tileManager, this.playerPrefab);
        }
        catch (Exception e) 
        {
            Debug.LogError("Error spawning player: " + e.Message);
        }
    }

    void SpawnEnemy()
    {
        EnemySpawn enemySpawn = gameObject.AddComponent<EnemySpawn>();
        try
        {
            enemySpawn.SpawnEnemy(this.tileManager, this.enemyPrefab);
        }
        catch (Exception e)
        {
            Debug.LogError("Error spawning enemy: " + e.Message);
        }
    }
}
