using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField]private float moveSpeed = 5f;
    private bool movingForward = true;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        // Check if the NPC is going out of the camera's viewport
        if (viewportPosition.x <= 0 || viewportPosition.x >= 1 || viewportPosition.y <= 0 || viewportPosition.y >= 1)
        {
            // Randomly change direction
            if (Random.value < 0.5f)
            {
                movingForward = !movingForward;
            }
            else
            {
                // Randomize direction
                float randomX = Random.Range(-1f, 1f);
                float randomY = Random.Range(-1f, 1f);
                Vector3 randomDirection = new Vector3(randomX, randomY, 0f).normalized;
                Move(randomDirection);
            }
        }

        if (movingForward)
        {
            Move(new Vector3(0f, 1f, 0f));
        }
        else
        {
            Move(new Vector3(0f, -1f, 0f));
        }
    }

    public void Move(Vector3 direction)
    {
        transform.position += direction.normalized * moveSpeed * Time.deltaTime;
    }
}