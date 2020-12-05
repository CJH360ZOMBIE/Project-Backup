using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShells : MonoBehaviour
{
    public Transform EmptyPoint;
    public GameObject ShellPrefab;
    public float ExitSpeed = 20f;
    public float FireRate;

    float ReadyForNextShot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            if(Time.time > ReadyForNextShot)
            {
                ReadyForNextShot = Time.time + 1/FireRate; // Invoke("Empty", 0.2f);//this will happen after x seconds
                Empty();
            }
        }
    }

    void Empty()
    {
        GameObject bullet = Instantiate(ShellPrefab, EmptyPoint.position, EmptyPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector3.up * ExitSpeed, ForceMode2D.Impulse); 
    }

     void OnBecameInvisible() 
     {
        Destroy(ShellPrefab);
     }
}
