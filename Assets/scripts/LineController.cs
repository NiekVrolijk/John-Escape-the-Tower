using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Transform[] points;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    public void SetUpLine(Transform[] points) 
    {
        lineRenderer.positionCount = points.Length;
        this.points = points;
    }
    void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            lineRenderer.SetPosition(i, points[i].position);
        }
    }
}
