using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavaScriptBridge : MonoBehaviour
{
    public GameObject hero;
    public Material wing_cockpit_mat;


    private void Awake()
    {
        wing_cockpit_mat.color = new Color(174 / 255f, 177 / 255f, 184 / 255f);
    }

    public void updateBounds()
    {
        StartCoroutine(waitUpdateBounds());
    }

    public void changeColorRed()
    {
        wing_cockpit_mat.color = Color.red;
    }

    public void changeColorBlue()
    {
        wing_cockpit_mat.color = Color.blue;
    }

    public void changeColorPurple()
    {
        wing_cockpit_mat.color = new Color(192 / 255f, 52 / 255f, 235 / 255f);
    }

    IEnumerator waitUpdateBounds()
    {
        yield return new WaitForSeconds(0.1f);

        BoundsCheck boundsCheckScript = hero.GetComponent<BoundsCheck>();
        boundsCheckScript.camHeight = Camera.main.orthographicSize;

        float camHeight = boundsCheckScript.camHeight;

        boundsCheckScript.camWidth = camHeight * Camera.main.aspect;
    }
}
