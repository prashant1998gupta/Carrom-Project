using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrikerMover : MonoBehaviour
{
   
    float min , max;
    float Loc;
    public Slider SliderDis;

    void Start()
    {
        SliderDis = GetComponent<Slider>();
    }  

    void UpdateObjectPositionBySlider()
    {
        Loc = SliderDis.value;
        var moveableDistance = max - min;
        var changeInDistance = moveableDistance * Loc / 100;
        var currentPosition = changeInDistance + min;
        
        transform.position = new Vector3(currentPosition , transform.position.y , transform.position.z);

        
         
    }    

}
