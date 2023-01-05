using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public GameObject weapon;

    public Transform attackPoint;

    public float attackRange = 0.5f;

    public LayerMask enemyLayers;

    public float attackCooldown = 1f;
    public float lastSwing;

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastSwing > attackCooldown)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                lastSwing = Time.time;
                Attack();
            }        
        }
    }

    private void Attack()
    {
        Animator anim = weapon.GetComponent<Animator>();
        anim.SetTrigger("Attack");

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name + " has been hit");
            Weapon playerWeapon = weapon.GetComponent<Weapon>();

            Damage damage = new Damage
            {
                damageAmount = playerWeapon.damagePoint,
                origin = playerWeapon.transform.position,
                pushForce = playerWeapon.pushForce
            };

            enemy.gameObject.SendMessage("ReceiveDamage", damage); 
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
