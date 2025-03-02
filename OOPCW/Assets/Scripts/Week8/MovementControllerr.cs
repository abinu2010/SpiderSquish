using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControllerr : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private void Start()
    {
        MoveToTarget(new Vector3(5f, 5f, 5f));
    }
    private void Update()
    {
        if (!isMoving)
        {

            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
            }
        }        
    }
    public void MoveToTarget(Vector3 target)
    {
        targetPosition = target;
        isMoving = true;
    }
}
