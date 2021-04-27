using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class controls the Hero's movement and properties
/// </summary>
public class Hero : MonoBehaviour
{
    //Singleton for the Hero class
    static public Hero S;

    [Header("Set in Inspector")]
    //These variables control the ship movement
    public float speed = 30;
    public float rollMult = -30;
    public float pitchMult = 20;
    public float gameRestartDelay = 2f;     //The game's delay time before a restart (in seconds)
    public GameObject projectilePrefab;     //Variable to reference the projectile prefab
    public float projectileSpeed = 50;      //Variable for the projectile speed

    //Variable to store the last triggering GameObject
    private GameObject lastTriggerGo = null;

    private void Awake()
    {
        //If there is no singleton, then set it
        if (S == null)
        {
            S = this;
        }

        //If there is more than one GameObject with the Hero script, then there is an error
        else
        {
            Debug.LogError("Hero.Awake() - Attempted to assign second Hero.S!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Get input from Input Class
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        //Change the position of ship based on the axes
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;

        //Rotate the ship to make it more dynamic
        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);

        //If the user hits the spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Run the TempFire() method to fire a projectile
            TempFire();
        }
    }

    //Method to shoot the projectile
    void TempFire()
    {
        //Create a projectile prefab
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);

        //Make the position of the projectile the same as the hero
        projGO.transform.position = transform.position;

        //Get the RigidBody component of the projectile
        Rigidbody rigidB = projGO.GetComponent<Rigidbody>();

        //Give the projctile a velocity to move it up
        rigidB.velocity = Vector3.up * projectileSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        //Gets the transform of the colliding GameObject's root
        Transform rootT = other.gameObject.transform.root;

        //Saving the colliding GameObject into a variable
        GameObject go = rootT.gameObject;

        //If the last triggering GameObject is the same as the current triggering GameObject
        if (go == lastTriggerGo)
        {
            //Exit
            return;
        }

        //Assigning the last triggering GameObject to the current one
        lastTriggerGo = go;

        //If the GameObject has the tag "Enemy"
        if (go.tag == "Enemy")
        {
            //Destory the GameObject
            Destroy(go);

            //Destory the player
            Destroy(this.gameObject);

            //Restart the game with a delay
            Main.S.DelayedRestart(gameRestartDelay);
        }

        //If not an enemy, print the object that collided
        else
        {
            print("Triggered by non-Enemy: " + go.name);
        }
    }
}
