using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Keeps the GameObject on the screen
/// </summary>
public class BoundsCheck : MonoBehaviour
{
    //Creating a variable to store the radius of the game object
    public float radius = 1f;

    //Creating a variable to force a GameObject to stay on the screen or exit the screen
    public bool keepOnScreen = true;

    //Creating variables to store the camera's width and height
    public float camWidth;
    public float camHeight;

    //Creating a variable to check if the GameObject is on the screen or not
    public bool isOnScreen = true;

    //Hides the variables in the line under from the Inspector
    [HideInInspector]
    //Creating variables to check if the GameObject goes off the screen (one for each side)
    public bool offRight, offLeft, offUp, offDown;

    void Awake()
    {
        //Camera.main gets access to first camera with tag "MainCamera"
        //Then it gets the size number from the inspector 
        //Gets the distance from game's origin to the top or bottom side of the screen
        camHeight = Camera.main.orthographicSize;

        //Camera.main.aspect gets access to the aspect ratio
        //Multiply by the camHeight to get distance from origin to left or right side of screen
        camWidth = camHeight * Camera.main.aspect;
    }

    void LateUpdate()
    {
        //Storing the current position into a variable
        Vector3 pos = transform.position;

        //isOnScreen starts off as true
        isOnScreen = true;

        //Sets all 4 variables to false
        offRight = offLeft = offUp = offDown = false;

        //If the x-coordinate of GameObject passes the right edge of the screen
        if (pos.x > camWidth - radius)
        {
            //Make the x-coordinate equal to the right edge of the screen (doesn't pass the right edge)
            pos.x = camWidth - radius;

            //The GameObject is off the right edge
            offRight = true;
        }

        //If the x-coordinate of GameObject passes the left edge of the screen
        if (pos.x < -camWidth + radius)
        {
            //Make the x-coordinate equal to the left edge of the screen (doesn't pass the left edge)
            pos.x = -camWidth + radius;

            //The GameObject is off the left edge
            offLeft = true;
        }

        //If the y-coordinate of GameObject passes the top edge of the screen
        if (pos.y > camHeight - radius)
        {
            //Make the y-coordinate equal to the top edge of the screen (doesn't pass the top edge)
            pos.y = camHeight - radius;

            //The GameObject is off the upper edge
            offUp = true;
        }

        //If the y-coordinate of GameObject passes the bottom edge of the screen
        if (pos.y < -camHeight + radius)
        {
            //Make the y-coordinate equal to the bottom edge of the screen (doesn't pass the bottom edge)
            pos.y = -camHeight + radius;

            //The GameObject is off the bottom edge
            offDown = true;
        }

        //If the GameObject is meant to stay on the screen and is currently off the screen
        if (keepOnScreen && !isOnScreen)
        {
            //Update the position to be on the screen
            transform.position = pos;
        }

        //If it the GameObject is off of any sides of the screen, the GameObject is not on the screen
        isOnScreen = !(offRight || offLeft || offUp || offDown);

        //If the GameObject meant to stay on the screen and it is not currently on the screen
        if (keepOnScreen && !isOnScreen)
        {
            //Update the position to be on the screen
            transform.position = pos;

            //It is now on the screen
            isOnScreen = true;

            //It is not out of bounds
            offRight = offLeft = offUp = offDown = false;
        }
    }

    //Draws the boundries in the Scene pane
    void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 boundSize = new Vector3(camWidth * 2, camHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
}
