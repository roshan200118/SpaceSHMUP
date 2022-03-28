using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavaScriptBridge2 : MonoBehaviour
{
    public GameObject wing;
    private Material wingMaterial;

    public GameObject hero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.P))
        {
            /*wingMaterial = wing.GetComponent<Renderer>().material;
            wingMaterial.color = Color.red;
            //StartCoroutine(wait());

            Hero heroScript = hero.GetComponent<Hero>();
            heroScript.speed = 50;
        }*/
    }

    public void changeColor()
    {
        wingMaterial = wing.GetComponent<Renderer>().material;
        wingMaterial.color = Color.red;
    }

    public void updateBounds()
    {
        changeColor();
        StartCoroutine(wait2());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
        changeColor();
    }

    IEnumerator wait2()
    {
        yield return new WaitForSeconds(0.1f);
        changeColor();

        BoundsCheck boundsCheckScript = hero.GetComponent<BoundsCheck>();
        boundsCheckScript.camHeight = Camera.main.orthographicSize;

        float camHeight = boundsCheckScript.camHeight;

        boundsCheckScript.camWidth = camHeight * Camera.main.aspect;
    }

}
