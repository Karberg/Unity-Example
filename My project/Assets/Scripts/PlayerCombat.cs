using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    [SerializeField] private LayerMask enemyLayers;

    public int attackDamage = 20;

    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public string attackKey;

    public float DamageDelay = 1f;


    // Update is called once per frame
    void Update()
    {
        
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(attackKey))
        {
            nextAttackTime = Time.time + 1f / attackRate;
            Attack();
            
        }
        }
    }

    

        private IEnumerator DelayForDamage()
    {
        yield return new WaitForSeconds(DamageDelay);

        //detect enemies in range of the attack range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //damage enemy player
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }


    void Attack()
    {
        // play an attack animation
        animator.SetTrigger("Attack");

        // Detects enemies in range and damages them after a set time delay
        StartCoroutine(DelayForDamage());
        
            
    }
    
    void OnDrawGizmosSelected()
        {
            if (attackPoint == null)
                return;
            
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
      
        }

    
    
    
    
    










}
