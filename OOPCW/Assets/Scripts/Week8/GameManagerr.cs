using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerr : MonoBehaviour
{
    public TileManager2 tileManager;
    public GameObject walkablee;
    public GameObject unwalkablee;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        MakeBoard();
        
    }
    void MakeBoard()
    {
        if (tileManager != null && walkablee != null && unwalkablee != null)
        {
            tileManager.MakeBoard();
            MovePlayerToTarget(new Vector3(5f, 5f, 5f));
            int boardHeight = tileManager.boardHeight;
            int boardWidth = tileManager.boardWidth;
            for (int i = 0; i < boardHeight; i++)
            {
                for(int j = 0; j < boardWidth; j++)
                {
                    GameObject tilePrefab;
                    int bitValue = tileManager.bitBoard[i, j];

                    if (bitValue == 0)
                    {
                        tilePrefab = walkablee;
                    }
                    else
                    {
                        tilePrefab = unwalkablee;
                    }
                    Vector3 tilePosition = new Vector3(j, -i, 0);
                    Instantiate(tilePrefab, tilePosition, Quaternion.identity, tileManager.transform);
                }
            }


        }
    }
    void MovePlayerToTarget(Vector3 targetPosition)
    {
        MovementControllerr mc = Player.GetComponent<MovementControllerr>();
        if (mc != null)
        {
            mc.MoveToTarget(targetPosition);
        }
    }
}
