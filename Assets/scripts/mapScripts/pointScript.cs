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

    public Encountercontroller encounterController;

    // Dictionary to define connections between tiles (2D islands)
    private Dictionary<int, List<int>> tileConnections = new Dictionary<int, List<int>>();

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.sharedMaterial = unexploredMaterial;
        johnHasBeen = false;

        // Initialize the connections between islands (can be modified for your map)
        tileConnections[0] = new List<int> { 1, 2 }; // Start Tile is connected to Tile 1 and 2
        tileConnections[1] = new List<int> { 0, 3 }; // Tile 1 is connected to Tile start, 3
        tileConnections[2] = new List<int> { 0, 4, 5 }; // Tile 2 is connected to Tile start, 4 and 5
        tileConnections[3] = new List<int> { 1, 4, 6 }; //etc.
        tileConnections[4] = new List<int> { 2, 3, 7 };
        tileConnections[5] = new List<int> { 2, 7 };
        tileConnections[6] = new List<int> { 3, 9 };
        tileConnections[7] = new List<int> { 4, 5, 8, 9 };
        tileConnections[8] = new List<int> { 7, 9 };
        tileConnections[9] = new List<int> { 6, 7, 8, 10, 11, 12 }; //trader
        tileConnections[10] = new List<int> { 9, 13 };
        tileConnections[11] = new List<int> { 9, 13, 14 };
        tileConnections[12] = new List<int> { 9, 14 };
        tileConnections[13] = new List<int> { 10, 11, 16, 17 };
        tileConnections[14] = new List<int> { 11, 12, 15, 17, 18 };
        tileConnections[15] = new List<int> { 14, 18 };
        tileConnections[16] = new List<int> { 13, 19 };
        tileConnections[17] = new List<int> { 13, 14, 19 };
        tileConnections[18] = new List<int> { 14, 15, 19 };
        tileConnections[19] = new List<int> { 16, 17, 18 }; //end

        // Ensure there is a 2D collider for detecting clicks
        if (GetComponent<Collider2D>() == null)
        {
            gameObject.AddComponent<CircleCollider2D>();
        }
    }

    void Update()
    {
        TileStatus();
    }

    public void TileStatus()
    {
        // Update material based on John's location
        if (pointID == JohnScript.johnLocation && rend.sharedMaterial != johnMaterial)
        {
            rend.sharedMaterial = johnMaterial;
            johnHasBeen = true;
        }

        if (johnHasBeen && pointID != JohnScript.johnLocation && rend.sharedMaterial != exploredMaterial)
        {
            if (pointID != 0 && pointID != 9 && pointID != 19) // Modify this if you have specific tile behavior
            {
                rend.sharedMaterial = exploredMaterial;
            }
            else
            {
                rend.sharedMaterial = unexploredMaterial;
            }
        }
    }



    // This method will be triggered when the player clicks on the island
    void OnMouseDown()
    {
        List<int> connectedTiles;

        // Check if the current tile has connections defined
        if (tileConnections.TryGetValue(JohnScript.johnLocation, out connectedTiles))
        {
            // Only allow movement if the clicked tile is connected to the current johnLocation
            if (connectedTiles.Contains(pointID))
            {
                JohnScript.johnLocation = pointID;
                JohnScript.UpdateRations(-100);
                if (!CompareTag("Special"))
                {
                    encounterController.OnEnterTile(pointID);
                }
            }
            else
            {
                Debug.Log("No line connecting these islands!");
            }
        }
        else
        {
            Debug.Log("Current tile has no connections defined.");
        }
    }
}
