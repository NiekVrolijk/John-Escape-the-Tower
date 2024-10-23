using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (rations <= 0)
        {
            SceneManager.LoadScene("DeathScene");
        }
        if (johnLocation == 19) 
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
