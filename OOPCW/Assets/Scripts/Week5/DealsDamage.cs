using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealsDamage : MonoBehaviour
{
    public int damageDealt = 2;

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject objectHit = collider.gameObject;
        Damageable damageable = objectHit.GetComponent<Damageable>();

        if (damageable != null)
        {
            damageable.ReceiveDamage(damageDealt);
            Destroy(gameObject); 
        }
    }
}
