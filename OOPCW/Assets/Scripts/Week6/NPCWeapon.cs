using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWeapon : MonoBehaviour
{
    public Rigidbody2D bulletPrefab;
    public float fireRate = 2f;
    public float bulletLifetime = 3f;
    public float bulletSpeed;

    private float nextFireTime = 0f;
    private NPCAI npcAI;

    private void Start()
    {
        npcAI = GetComponentInParent<NPCAI>();
    }

    private void Update()
    {
        if (Time.time >= nextFireTime && npcAI.currentState == NPCAI.AIState.Attacking)
        {
            nextFireTime = Time.time + 1f / fireRate;
            FireBullet();
        }
    }

    public void FireBullet()
    {
        Vector2 direction = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized;
        Rigidbody2D bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bulletInstance.velocity = direction * bulletSpeed;
        Destroy(bulletInstance.gameObject, bulletLifetime);
    }
}
