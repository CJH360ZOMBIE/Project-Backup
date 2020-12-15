using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class GameManager : MonoBehaviour
{
    public Text TimerText;
    private float startTime;
    private int CurrentAmmo;
    public Canvas canvas;
    public Transform bar; 
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        bar.localScale = new Vector3(.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (canvas.enabled == true)
        {
        
        float t = Time.time - startTime;

        string Seconds = (t % 999999).ToString("f2");

        // "f1" = n.o  floats i.e f1 = 1 

        TimerText.text = Seconds; 

        }
    }

    public void SetSize (float sizenormalized)
    {
        bar.localScale = new Vector3 (sizenormalized, 1f);
    }
}