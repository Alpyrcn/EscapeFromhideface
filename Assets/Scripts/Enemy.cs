using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region VARIABLES

    public float health;
    public float maxHealth;

    public float damageAmount = 10f;

    public float attackCooldown = 2f;
    private float lastAttackTime;
    #endregion

    #region MOONOBEHAVIOUR

    private void Start()
    {
        health = maxHealth;
    }

    #endregion

    #region METHOD

    public void TakeDamage(float damage)
    {
        health -= damage;

        // Saðlýk sýfýra düþtüðünde ölüm iþlemlerini burada gerçekleþtirebilirsiniz.
        if (health <= 0)
        {
            Die();
        }
    }

    public void UpdateHealth(float amount)
    {
        health += amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void GiveDamage(Player player)
    {
        player.TakeDamage(10f);
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private bool CanAttack()
    {
        // Saldýrý yapmak için belirli bir süre beklemiþ olmalý
        return Time.time - lastAttackTime >= attackCooldown;
    }
    private void Attack()
    {
        
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            player.TakeDamage(damageAmount);
            lastAttackTime = Time.time;
        }
    }

    #endregion

}
