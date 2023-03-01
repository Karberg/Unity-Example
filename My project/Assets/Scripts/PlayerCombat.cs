using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    [SerializeField] private LayerMask enemyLayers;

    public int attackDamge = 20;

    public float attackRate = 2f;
    float nextAttackTime = 0f;



    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
        }
    }


    void Attack()
    {
        // play an attack animation
        animator.SetTrigger("Attack");

        //detect enemies in range of the attack range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //damge them
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamge);
        }
    }
    
    void OnDrawGizmosSelected()
        {
            if (attackPoint == null)
                return;
            
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
      
        }

    
    
    
    
    










}
