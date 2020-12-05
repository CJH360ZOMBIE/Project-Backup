using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text TimerText;
    private float startTime;
    private int CurrentAmmo;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;

        string Seconds = (t % 999999).ToString("f2");

        // "f1" = n.o  floats i.e f1 = 1 

        TimerText.text = Seconds; 

    }
}
