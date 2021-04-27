using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class controls the background movement
/// </summary>
public class Parallax : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject poi;              //Creating a variable to reference the hero ship
    public GameObject[] panels;         //Creating an array to store the foregrounds for scrolling
    public float scrollSpeed = -30f;    //Creating a variable for scroll speed
    public float motionMult = 0.25f;    //Creating a variable for how much panels react to player movement

    //Creating a variable for the height of the panel
    private float panelHt;

    //Creating a variable for the depth of the panels (z-axis)
    private float depth;

    // Start is called before the first frame update
    void Start()
    {
        //Get the panels height and depth
        panelHt = panels[0].transform.localScale.y;
        depth = panels[0].transform.position.z;

        //Set the inital position of the panels
        panels[0].transform.position = new Vector3(0, 0, depth);
        panels[1].transform.position = new Vector3(0, panelHt, depth);
    }

    // Update is called once per frame
    void Update()
    {
        //Creating variables for the x and y values
        float tY, tX = 0;

        //Setting the y-value
        tY = Time.time * scrollSpeed % panelHt + (panelHt * 0.5f);

        //If the hero exists
        if (poi != null)
        {
            //Set the x-value
            tX = -poi.transform.position.x * motionMult;
        }

        //Update the position of the first panel
        panels[0].transform.position = new Vector3(tX, tY, depth);

        //If the y-value is greater or equal to 0
        if (tY >= 0)
        {
            //Update the second panel's position accordingly
            panels[1].transform.position = new Vector3(tX, tY - panelHt, depth);
        }

        //If the y-value is less than 0
        else
        {
            //Update the second panel's position accordingly
            panels[1].transform.position = new Vector3(tX, tY + panelHt, depth);
        }
    }
}
