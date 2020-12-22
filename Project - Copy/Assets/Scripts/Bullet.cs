using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
        //https://www.youtube.com/watch?v=bY4Hr2x05p8
    public int Damage; 
    public float Speed; 
    public float Lifetime; 
    public float distance; 
    public LayerMask WhatIsSolid; 
    public GameObject Destroyeffect; 

    void start()
    {
            Invoke("DestroyBullet", Lifetime);
    }

    void Update()
    {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, WhatIsSolid);
            if (hitInfo.collider != null)
            {
                    if (hitInfo.collider.CompareTag("Enemy"))
                    {          
                            hitInfo.collider.GetComponent<Enemy>().TakeDamage(Damage);
                    } 
                    DestroyBullet(); Instantiate(Destroyeffect, transform.position, Quaternion.identity); 
            }
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
