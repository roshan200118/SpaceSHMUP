using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Extends the Enemy class
//Enemy 2 moves in a 45 degree pattern
public class Enemy_2 : Enemy
{
    //Creating a variable to check if the enemy is moving right
    private bool moveRight;

    // Start is called before the first frame update
    void Start()
    {
        //Pick a random side to move in 
        PickMovingSide();
    }

    // Update is called once per frame
    void Update()
    {
        //Run the move method
        Move();
    }

    //Method to move Enemy 2
    public override void Move()
    {
        //Creating a variable to store the current position
        Vector3 tempPos = pos;

        //The moveRight is true
        if (moveRight)
        {
            //Move the enemy to the right with respect to time
            tempPos.x += speed * Time.deltaTime;

            //If the enemy is off the right side of the screen
            if (this.bndCheck.offRight)
            {
                //Destory the enemy
                Destroy(gameObject);
            }
        }

        else
        {
            //Move the enemy to the left with respect to time
            tempPos.x -= speed * Time.deltaTime;

            //If the enemy is off the left side of the screen
            if (this.bndCheck.offLeft)
            {
                //Destory the enemy
                Destroy(gameObject);
            }
        }

        //Update the position
        pos = tempPos;

        //Call the superclass Move() method (moves the enemy down)
        base.Move();
    }

    //Method to randomly pick a side to start moving in 
    //Ex) Start moving (right and down) or (left and down) in a 45 degree angle
    public void PickMovingSide()
    {
        //Randomly generate a number between 0 and 1
        //If the number is 1
        if (Random.Range(0, 2) == 1)
        {
            //The the enemy starts moving down right
            moveRight = true;
        }

        //If the number is 0
        else
        {
            //The enemy starts moving down left 
            moveRight = false;
        }
    }
}
