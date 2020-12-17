using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shooting : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public float BulletForce = 20f;
    public Animator animator;
    public float FireRate;
    public float ReloadTime = 1f;
    public float MouseOffset;   //gun rotation
    public int MaxAmmo = 10;
    public ParticleSystem MuzzleFlash;  
    // public Transform EmptyPoint;
    // public GameObject ShellPrefab;
    public float ExitSpeed = 20f;
    private int CurrentAmmo;
    private bool isReloading = false;
    public Transform weapon; // weapon flip
    public float speed = 50f; 
    private Transform Player; 
    public Vector2 direction;

    float ReadyForNextShot;
    public Rigidbody2D PlayerRb; 

    void start()
    {
        PlayerRb = Player.GetComponent<Rigidbody2D>();
        CurrentAmmo = MaxAmmo;
    }

    

    // Update is called once per frame
    void Update()
    {  
        if(isReloading)
        return;

        if(CurrentAmmo <= 0f)
        {
            StartCoroutine(Reload());
            return; // wont continue onto the next statement below
        }
        if(Input.GetButton("Fire1"))
        {
            if(Time.time > ReadyForNextShot)
            {
                
                ReadyForNextShot = Time.time + 1/FireRate;
                Shoot(); Empty();
                {
                    MuzzleFlash.Play(); 
                }
                return;
            } 
            


        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if(CurrentAmmo < MaxAmmo)
            {
                StartCoroutine("Reload"); 
            }
            
        }

        
    }



    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(FirePoint.up * BulletForce, ForceMode2D.Impulse); 
        animator.SetTrigger("Shoot"); //*IMPORTANT* make sure trigger name is set to "Shoot" 

        CurrentAmmo --; // - 1 
    }

        void GunJump()
    {
        PlayerRb.AddForce(Vector2.up * speed);
    }
    IEnumerator Reload()
    {
        isReloading = true;
       Debug.Log("RELOADIN'");

       animator.SetBool("Reloading", true); //*IMPORTANT* make sure animator name is set to "Reloading" 

       yield return new WaitForSeconds(ReloadTime - .25f);

       animator.SetBool("Reloading", false);

       yield return new WaitForSeconds(.25f);

       CurrentAmmo = MaxAmmo; 
       isReloading = false;
    }
    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading",false);
    }

        void Empty()
    {
        // GameObject bullet = Instantiate(ShellPrefab, EmptyPoint.position, EmptyPoint.rotation);
        Rigidbody2D rb = bulletPrefab.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector3.up * ExitSpeed, ForceMode2D.Impulse); 
    }

     void OnBecameInvisible() 
     {
        // Destroy(ShellPrefab);
        Destroy(bulletPrefab);
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

        if(Input.GetButton("Fire1") && rotZ < 90f)
        {
            GunJump();
        }  
    }
}

