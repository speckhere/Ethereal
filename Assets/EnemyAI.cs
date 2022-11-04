  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

public Transform target;
public Animator animator;

public float speed = 200f;
public float nextWaypointDistance = 3f;

public Transform ShroomGFX;

Path path;
int currentWaypoint = 0;

Seeker seeker;
Rigidbody2D rb;

public int maxHealth = 100;
public int currentHealth;
public HealthBar healthBar;

private bool m_FacingRight = true;  // For determining which way the player is currently facing.
private Vector2 pos;
public float startPos;

private Transform childObj;


    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        startPos = pos.x;

        InvokeRepeating("UpdatePath", 0f, .5f);

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        childObj = transform.Find("HEALTH");
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void Update()
    {
        float currentPos = transform.position.x;

        if(currentPos > startPos && !m_FacingRight)
        {
            Flip();
        }
        else if(currentPos < startPos && m_FacingRight)
        {
            Flip();
        }

        startPos = currentPos;

    }
    void FixedUpdate()
    {
        if (path == null)
            return;

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        } else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if(force.x >= 0.01f)
        {
            ShroomGFX.localScale = new Vector3(-1f, 1f, 1f);
        } else if (force.x <= -0.01f)
        {
            ShroomGFX.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        Debug.Log("Hiyaa!");

        animator.SetTrigger("Hurt");

        // play hurt animation

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("GET SHIT ON!");

        animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        //childObj.enabled = false;
        this.enabled = false;

    }

    private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
