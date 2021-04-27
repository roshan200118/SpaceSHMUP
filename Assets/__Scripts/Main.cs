using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Used for loading and reloading of scenes

/// <summary>
/// This class controls the game components such as enemy spawn and restarting
/// </summary>
public class Main : MonoBehaviour
{
    //Singleton for Main
    static public Main S;

    [Header("Set in Inspector")]
    //Creating an array to store the enemies
    public GameObject[] prefabEnemies;

    //Number of enemies/second
    public float enemySpawnPerSecond = 0.5f;

    //Padding for position
    public float enemyDefaultPadding = 1.5f;

    //Creating a variable to reference the BoundsCheck script
    private BoundsCheck bndCheck;

    void Awake()
    {
        //Assigning the Singleton
        S = this;

        //Set bndCheck to reference the BoundsCheck component of the GameObject
        bndCheck = GetComponent<BoundsCheck>();

        //Calls the SpawnEnemy() method in 1/0.5 = 2 seconds
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }

    public void SpawnEnemy()
    {
        //Creating a variable to store a random number between 0 and the number of enemy prefabs (2)
        int ndx = Random.Range(0, prefabEnemies.Length);

        //Creates a enemy based on the value of ndx
        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);

        //The enemy padding is set to the default enemy padding
        float enemyPadding = enemyDefaultPadding;
        //If the enemy prefab has a BoundsCheck component
        if (go.GetComponent<BoundsCheck>() != null)
        {
            //Set the enemy padding to the absolute value of the radius of the BoundsCheck component
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
        }

        //Creating a variable to store the position of the enemy
        Vector3 pos = Vector3.zero;

        //Creating variables so it is in the horizontal range of the screen
        float xMin = -bndCheck.camWidth + enemyPadding;
        float xMax = bndCheck.camWidth - enemyPadding;

        //The x-coordinate is a random value that is on the screen
        pos.x = Random.Range(xMin, xMax);

        //The y-coordinate is a value just above teh top edge of the screen
        pos.y = bndCheck.camHeight + enemyPadding;

        //Update the position
        go.transform.position = pos;

        //Calls the SpawnEnemy() method in 1/0.5 = 2 seconds
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }

    //Method to restart with a delay
    public void DelayedRestart(float delay)
    {
        //Runs the Restart() method in delay amount of seconds
        Invoke("Restart", delay);
    }

    //Method to restart the game
    public void Restart()
    {
        //Reload the scene to restart the game
        SceneManager.LoadScene("_Scene_0");
    }
}
