using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageablePlayer : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    private Manager gameManager;

    private void Start()
    {
        currentHealth = maxHealth;
        GameObject[] gameManagers = GameObject.FindGameObjectsWithTag("GameManager");

        foreach (GameObject manager in gameManagers)
        {
            if (manager.layer == LayerMask.NameToLayer("UI"))
            {
                gameManager = manager.GetComponent<Manager>();
                break;
            }
        }
    }

    public void DealDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    private void Die()
    {
        if (gameManager != null)
        {
            gameManager.PlayerDied();
        }
    }
}

