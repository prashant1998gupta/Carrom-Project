using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Striker : MonoBehaviour
{
    public static int i;
    public Transform striker;
     Rigidbody2D rd;

    void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            rd.AddForce(transform.up*5, ForceMode2D.Impulse);
        }
    }

}
