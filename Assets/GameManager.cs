using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector3 initPos;
    public float speed ;
    public float speedTime = 0.5f;
    private GameObject striker;
    
    void Awake()
    {
        striker = GameObject.FindGameObjectWithTag("Striker");
    }

    
    void FixedUpdate()
    {
        StartCoroutine(SrikerStaringPos());
       
    }

    IEnumerator SrikerStaringPos()
    {
        
        yield return new WaitForSeconds(5f);
    }

}
