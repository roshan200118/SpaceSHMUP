using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class controls the boundries for the projecile
/// </summary>
public class Projectile : MonoBehaviour
{
    //Creating a variable to reference the BoundsCheck script
    private BoundsCheck bndCheck;

    void Awake()
    {
        //Gets the BoundsCheck script component from the GameObject
        //If no such component, it will be set to null
        bndCheck = GetComponent<BoundsCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        //If the projectile is past the upper edge
        if (bndCheck.offUp)
        {
            //Destory the projectile
            Destroy(gameObject);
        }
    }
}
