using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;

    public float jumpPower = 10.0f;
    // public GameObject hitEffect;

    void start()
    {

    }
 void OnBecameInvisible() //destroys bullet when out of screen bounds
{
        Destroy (bullet);
}
}
