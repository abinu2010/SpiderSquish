using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Rigidbody2D ProjectileRB;
    public float bulletSpeed = 2.0f;
    public float projectileLifetime = 3.5f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireWeapon();
        }
    }

    public void FireWeapon()
    {
        GameObject newProjectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = transform.up * bulletSpeed;
        }
        else
        {
            Debug.LogError("Projectile prefab must have a Rigidbody2D component.");
        }

        Destroy(newProjectile, projectileLifetime);
    }
}
