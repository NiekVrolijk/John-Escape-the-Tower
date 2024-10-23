using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnScript : MonoBehaviour
{
    public static int rations;
    public static int johnLocation = 0;

    // Start is called before the first frame update
    void Start()
    {
        rations = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rations);
    }
}
