using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private GameObject personCollecting;

    void OnCollisionEnter2D(Collision2D collision)
    {
        personCollecting = collision.gameObject;

        if (personCollecting.CompareTag("Player"))
        {
            CollectKey();
        }

        Destroy(gameObject);
    }

    void CollectKey()
    {
        Debug.Log("Got key");
        PlayerInventory playerInventory = personCollecting.GetComponent<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.SetKey(true);
        }
    }
}
