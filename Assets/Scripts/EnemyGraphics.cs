using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGraphics : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public AIPath aiPath;
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.0f)
        {
            spriteRenderer.flipX = false;
        } else if (aiPath.desiredVelocity.x < 0.0f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
