using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloner : MonoBehaviour
{
    [SerializeField] private GameObject blueprintObject;
    [SerializeField] private Vector2 spawnPosition;
    [SerializeField] private Vector2 targetPosition;
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float moveDelay = 0.0f;
    [SerializeField] private bool destroyOnReachTarget = false;

    private float lerpProgress = 0.0f;
    private bool isMovementStarted = false;
    private GameObject copyOfBlueprint;

    void Start()
    {
        copyOfBlueprint = GameObject.Instantiate(blueprintObject, spawnPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMovementStarted)
        {
            if (Time.time >= moveDelay)
            {
                isMovementStarted = true;
            }
            else
            {
                return;
            }
        }

        lerpProgress += Time.deltaTime * moveSpeed;
        copyOfBlueprint.transform.position = Vector2.Lerp(spawnPosition, targetPosition, lerpProgress);
        lerpProgress = Mathf.Clamp01(lerpProgress);
        if (lerpProgress >= 1.0f && destroyOnReachTarget)
        {
            Destroy(copyOfBlueprint);
            copyOfBlueprint = GameObject.Instantiate(blueprintObject, spawnPosition, Quaternion.identity);
        }
    }
}

