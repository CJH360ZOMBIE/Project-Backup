using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //https://www.youtube.com/watch?v=bY4Hr2x05p8

    public Transform target;
    public Transform Weapon;
    public int Health; 
    public GameObject DeathEffect;
    public void TakeDamage(int Damage)
    {
        Health -= Damage;
    } 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
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
}
