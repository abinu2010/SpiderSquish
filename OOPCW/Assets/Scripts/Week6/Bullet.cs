using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DamageablePlayer damageablePlayer = collision.GetComponent<DamageablePlayer>();
            if (damageablePlayer != null)
            {
                damageablePlayer.DealDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
