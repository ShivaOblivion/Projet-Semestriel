using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator;
    public HealthBar healthBar;
    public int healthUp;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void update()
    {


        if (Input.GetKeyDown(KeyCode.H))
        {
            takeDamage(20);
        }
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void  Die()
    {
        animator.SetBool("playerDeath", true);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Health up")
        {
            currentHealth += healthUp ;
            Destroy(other.gameObject);
        }
    }
}    
   