using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float horizontal = 1f;
    public float vertical = 1f;
    public float moveSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
       Rigidbody2D rb = GetComponent<Rigidbody2D>();
       rb.velocity = new Vector2(horizontal, vertical);
        
    }

    // Update is called once per frame
    void Update()
    {
       horizontal =  Input.GetAxisRaw("Horizontal") * moveSpeed;
       vertical =  Input.GetAxisRaw("Vertical") * moveSpeed;
       
    }
}
