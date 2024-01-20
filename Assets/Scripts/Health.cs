using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //[SerializeField] private AudioSource deathSoundEffect;
    public HealthBar healthBar;
    public int maxHealth = 10;
    public int health;
    public GameManager gameManager;

    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0 && !isDead)
        {
            //deathSoundEffect.Play();
            isDead = true;
            gameManager.gameOver();
            Destroy(gameObject);
        }
        healthBar.SetHealth(health);
    }
}

