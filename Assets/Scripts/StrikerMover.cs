using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrikerMover : MonoBehaviour
{
    public GameObject Target;
    float m_Speed;
    float Loc;
    public Slider SliderDis;
    void Start()
    {
        SliderDis = GetComponent<Slider>();
        m_Speed = 10.0f;
        
    }
    void Update()
    {
        
        Loc = SliderDis.value;
        Debug.Log(Loc);
        Target.transform.position = new Vector3(Loc , Target.transform.position.y , 0.0f);
    }

}
