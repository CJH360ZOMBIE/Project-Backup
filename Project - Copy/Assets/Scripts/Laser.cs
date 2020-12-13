using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float laserlength;
    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 endPosition = transform.position + (transform.right * laserlength);
        lineRenderer.SetPositions(new Vector3[] { transform.position, endPosition });
    }
}
