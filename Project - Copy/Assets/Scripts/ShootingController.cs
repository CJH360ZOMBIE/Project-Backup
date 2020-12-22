using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    //https://www.youtube.com/watch?v=bY4Hr2x05p8
    public float MouseOffset;   //gun rotation
    public Transform weapon; // weapon flip
    public GameObject Bullet; 
    public Transform Firepoint; 
    private float TimeBetweenShots; 
    public float StartTimeBetweenShots; 
    public ParticleSystem MuzzleFlash;  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (TimeBetweenShots <= 0)
        {
        if (Input.GetButtonDown("Fire1"))
            {
            Instantiate(Bullet, Firepoint.position, transform.rotation); //make sure bullet prefab is FACING UP
            TimeBetweenShots = StartTimeBetweenShots; 
            EmitMuzzleFlash();
            }
        }
        else 
        {
            TimeBetweenShots -= Time.deltaTime; 
        }
    }

    void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //tut on BLACKTHORNPROD
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + MouseOffset); 

        if(rotZ < 89 && rotZ > -89)
        {
            return;
        } 
        else
        {
            weapon.Rotate(180,0,0);
        }

        // if(Input.GetButton("Fire1") && rotZ > 90f) 
        // {
        //     PlayerRb.AddForce(Vector2.right * speed);
        // }  ROCKET JUMP
    }

        private void EmitMuzzleFlash()
    {
        MuzzleFlash.Emit(30);
    }
}
