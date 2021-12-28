using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_0 : Enemy
{
    [Header("Set in Inspector: Enemy_0")]
    public float waveFrequency = 2;
    public float waveWidth = 4;
    public float waveRotY = 45;

    public float x0;
    public float birthTime;



    // Start is called before the first frame update
    void Start()
    {
        x0 = pos.x;

        birthTime = Time.time;
    }

    public override void Move()
    {
        Vector3 tempPos = pos;

        float age = Time.time - birthTime;
        float theta = Mathf.PI * 2 * age / waveFrequency;
        float sin = Mathf.Sin(theta);
        tempPos.x = x0 + waveWidth * sin;
        pos = tempPos;

        Vector3 rot = new Vector3(0, sin * waveRotY, 0);
        this.transform.rotation = Quaternion.Euler(rot);

        base.Move();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
