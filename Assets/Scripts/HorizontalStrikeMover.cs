using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalStrikeMover : MonoBehaviour
{
    public GameObject striker;
    public float xMin , xMax;

    private Touch touch;
    private float speedModifier;

    void Start()
    {
        speedModifier = .005f;
    }
   
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector2(Mathf.Clamp(transform.position.x, xMin, xMax) + touch.deltaPosition.x * speedModifier ,-3.1f);
            }
        }
       
    }
}
