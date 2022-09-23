using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    // collision states 
    public bool onGround;
    public bool onWall;
    public bool onRightWall;
    public bool onLeftWall;
    public int wallSide;

    [Space]

    [Header("Collision Checks")]

    public float collisionRadius = 0.25f;
    public Vector2 bottomOffset, rightOffset, leftOffset;
    private Color debugCollisionColor = Color.red;

    // Start is called before the first frame update
    void Start() 
    {

    }

    void Update() 
    {
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius);
        onWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius) 
            || Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius);

        onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius);
        onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius);

        wallSide = onRightWall ? -1 : 1;
    }
}