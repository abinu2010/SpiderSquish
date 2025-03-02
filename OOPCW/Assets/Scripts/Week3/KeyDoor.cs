using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public bool canOpen = false;
    private GameObject personOpening;

    void OpenDoor()
    {
        Debug.Log("Opened door");
        Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        personOpening = collision.gameObject;

        if (personOpening.CompareTag("Player"))
        {
            PlayerInventory playerInventory = personOpening.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                bool hasKey = playerInventory.GetHasKey();
               
                if (playerInventory.GetHasKey() && canOpen)
                {
                    OpenDoor();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
