using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the basic movement of an enemy (just moves down)
/// </summary>
public class Enemy : MonoBehaviour
{
    //Creating variables to control the enemy's movement
    public float speed = 10f;       //Speed in m/s

    //Creating a variable to reference the BoundsCheck script
    protected BoundsCheck bndCheck;

    //Creating a variable to reference the enemy's position
    public Vector3 pos
    {
        //Gets the position of the enemy
        get
        {
            return (this.transform.position);
        }

        //Sets the position of the enemy
        set
        {
            this.transform.position = value;
        }
    }

    void Awake()
    {
        //Gets the BoundsCheck script component from the GameObject
        //If no such component, it will be set to null
        bndCheck = GetComponent<BoundsCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        //Run the Move() method
        Move();

        //If the GameObject has a BoundsCheck script and it is off the bottom side of the screen
        if (bndCheck != null && bndCheck.offDown)
        {
            //Destory the GameObject
            Destroy(gameObject);
        }

    }

    //Method to move the enemy
    public virtual void Move()
    {
        //Creating a variable to store the enemy's current position
        Vector3 tempPos = pos;

        //Moves the enemy down
        tempPos.y -= speed * Time.deltaTime;

        //Updates the position
        pos = tempPos;
    }

    void OnCollisionEnter(Collision collision)
    {
        //Saving the GameObject of the collider into a variable
        GameObject otherGO = collision.gameObject;

        //If the collider was a hero's projectile
        if (otherGO.tag == "ProjectileHero")
        {
            //Destory the projectile
            Destroy(otherGO);

            //Destory the enemy
            Destroy(gameObject);
        }

        //If the collider was another object, print it in the console
        else
        {
            print("Enemy hit by non-ProjectileHero: " + otherGO.name);
        }
    }
}
