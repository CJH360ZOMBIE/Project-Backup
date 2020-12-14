using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public Transform EnemyGFX;
    public float speed = 10f; 
    public float nextWaypointdistance = 3f;
    public bool onGround = false;
    public float groundLength = 0.6f;
    Path path; 
    int currentwaypoint = 0; 
    bool Reachedendofpath = false;
    public LayerMask groundLayer;
    public Vector3 colliderOffset;

    Seeker seeker;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f );

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
            currentwaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null && onGround)
        return;

        if (currentwaypoint >= path.vectorPath.Count)
        {
            Reachedendofpath = true; 
            return;
        } else
        {
            Reachedendofpath = false;
        }
        Vector2 direction = ((Vector2)path.vectorPath[currentwaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentwaypoint]);

        if(distance < nextWaypointdistance)
        {
            currentwaypoint++;
        }
        //switch enemy rotation depending where the enemy is facing 
        if (force.x >= 0.01f)
        {
          EnemyGFX.localScale = new Vector3 (-1f, 1f, 1f);
        
        } else if (force.x <= -0.01f )
        {
            EnemyGFX.localScale = new Vector3 (1f, 1f, 1f);
        }
    }

    void Update()
    {
        onGround = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, groundLayer) || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, groundLayer);
    }
}
