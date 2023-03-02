using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    float nextAnimation = 0f;
    public float animationRate = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        {
            animator.SetTrigger("Hurt");
        }


        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Dying");
        // death animation
        animator.SetBool("IsDead", true);

        // Disable Script

        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;

    }
}
