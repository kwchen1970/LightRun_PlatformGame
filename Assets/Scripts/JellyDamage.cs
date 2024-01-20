using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyDamage : MonoBehaviour
{
    public int damage;
    public Health health;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            health.TakeDamage(damage);
        }
    }
}
