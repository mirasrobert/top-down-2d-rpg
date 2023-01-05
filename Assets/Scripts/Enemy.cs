using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    // Experience
    public int XP = 1;

    public float triggerLength = 1.0f;
    public float chaseLength = 5.0f;

    private bool chasing;
    private bool collidingWithPlayer;
    Transform playerTransform;
    Vector3 startingPosition;

    // Hitbox
    private BoxCollider2D hitBox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
    }

    protected override void Death()
    {
        base.Death();

        Destroy(gameObject);
    }


}
