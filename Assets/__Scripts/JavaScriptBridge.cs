using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavaScriptBridge : MonoBehaviour
{
    public GameObject hero;

    public void updateBounds()
    {
        StartCoroutine(waitUpdateBounds());
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
