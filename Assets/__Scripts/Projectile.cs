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

    private Renderer rend;

    [Header("Set Dynamically")]
    public Rigidbody rigid;
    [SerializeField]
    private WeaponType _type;

    public WeaponType type
    {
        get
        {
            return (_type);
        }
        set
        {
            SetType(value);
        }
    }


    void Awake()
    {
        //Gets the BoundsCheck script component from the GameObject
        //If no such component, it will be set to null
        bndCheck = GetComponent<BoundsCheck>();

        rend = GetComponent<Renderer>();
        rigid = GetComponent<Rigidbody>();
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

    public void SetType (WeaponType eType)
    {
        _type = eType;
        WeaponDefinition def = Main.GetWeaponDefinition(_type);
        rend.material.color = def.projectileColor;
    }

}
