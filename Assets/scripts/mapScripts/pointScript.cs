using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointScript : MonoBehaviour
{
    public int pointID = 0;

    public Material unexploredMaterial;
    public Material johnMaterial;
    public Material exploredMaterial;

    private bool johnHasBeen;

    private Renderer rend;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.sharedMaterial = unexploredMaterial;

        johnHasBeen = false;
    }
    void Update()
    {
        TileStatus();
    }

    public void TileStatus()
    {
        

        if (pointID == JohnScript.johnLocation && rend.sharedMaterial != johnMaterial)
        {
            rend.sharedMaterial = johnMaterial;
            johnHasBeen = true;
        }
        if (johnHasBeen && pointID != JohnScript.johnLocation && rend.sharedMaterial != exploredMaterial)
        {
            if (pointID != 0 && pointID != 9 && pointID != 19)
            {
                rend.sharedMaterial = exploredMaterial;
            } else
            {
                rend.sharedMaterial = unexploredMaterial;
            }
        }
    }
}
