using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public Transform Weapon;
    public float speed = 10f; 
    public float TargetFollowSpeed = 5f; 
    public float nextWaypointdistance = 3f;
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
        

    }        
    void Update()
    {
    //rotate weapon to follow player
    Vector3 difference = target.position - Weapon.position;
    float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
    Quaternion rotation = Quaternion.AngleAxis (rotZ, Vector3.forward);

    Weapon.rotation = Quaternion.Euler(0f, 0f, rotZ); 

        if(rotZ < 89 && rotZ > -89)
        {
            return;
        } 
        else
        {
            Weapon.Rotate(180,0,0);
        }
    }


        //switch enemy rotation depending where the enemy is facing 
    //     if (force.x >= 0.01f)
    //     {
    //       EnemyGFX.localScale = new Vector3 (-1f, 1f, 1f);
        
    //     } else if (force.x <= -0.01f )
    //     {
    //         EnemyGFX.localScale = new Vector3 (1f, 1f, 1f);
    //     }
    // }
}
