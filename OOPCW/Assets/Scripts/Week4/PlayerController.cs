using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject playerNew;
    public TileManager tileManager;

    private GameObject es;

    private Vector2Int enemyPosition;
    private bool isStartRan = false;


    void Start()
    {
        StartCoroutine(WaitForEnemy(0.1f));
        playerNew = GameObject.FindGameObjectWithTag("Player");
        

        tileManager = FindObjectOfType<TileManager>();
        if (tileManager == null)
        {
            Debug.LogError("TileManager not found.");
        }
        isStartRan = true;
    }

    IEnumerator WaitForEnemy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        es = GameObject.FindGameObjectWithTag("Enemy");

        Debug.Log("Finished waiting for " + waitTime + " seconds");
        enemyPosition = new Vector2Int(
            Mathf.RoundToInt(es.transform.position.x),
            Mathf.RoundToInt(es.transform.position.y)
        );
    }

    void Update()
    {
        if (!isStartRan)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MovePlayer(Vector2Int.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MovePlayer(Vector2Int.down);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MovePlayer(Vector2Int.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MovePlayer(Vector2Int.right);
        }
    }

    void MovePlayer(Vector2Int direction)
    {
        if (playerNew == null)
        {
            Debug.LogError("Player GameObject not found.");
            return;
        }

        Vector2Int currentPosition = new Vector2Int(
            Mathf.RoundToInt(playerNew.transform.position.x),
            Mathf.RoundToInt(playerNew.transform.position.y)
        );

        Vector2Int newPosition = currentPosition + direction;

        if (newPosition.x >= 0 && newPosition.x < tileManager.bitBoard.GetLength(1) &&
            newPosition.y >= 0 && newPosition.y < tileManager.bitBoard.GetLength(0))
        {
            bool cond1 = newPosition.y == enemyPosition.y && newPosition.x == enemyPosition.x;
            bool cond2 = (tileManager.bitBoard[newPosition.y, newPosition.x]) == 0;
            if (cond1 || cond2)
            {
                Debug.Log("Cannot move onto an unwalkable tile or a tile containing an enemy.");
                return;
            }
            Vector3 playerMovePosition = new Vector3(newPosition.x, newPosition.y, 0);
            playerNew.transform.position = playerMovePosition;
        }
        else
        {
            Debug.Log("Cannot move off the grid.");
        }
    }
}
