using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBySlider : MonoBehaviour
{
    public bool canMoveBySlider;

    [SerializeField]
    private float m_xMin, m_xMax;

    [SerializeField]
    private Slider m_slider;

    public Slider Slider1
    {
        get
        {
            m_slider.minValue = 0;
            m_slider.maxValue = 100;
           // m_slider.value = 50;
            return m_slider;
        }
        /*set
        {
            m_slider = value;
        }*/
    }
    void Start()
    {
        Slider1.onValueChanged.AddListener(delegate { UpdateObjectPosition(); });
    }
   

    public void UpdateObjectPosition()
    {
        if (canMoveBySlider)
        {
            var moveableDistance = m_xMax - m_xMin;
            var changeInDistance = (moveableDistance * Slider1.value) / 100;
            var currentPosition = changeInDistance + m_xMin;
            gameObject.transform.position = new Vector3(currentPosition  , transform.position.y , transform.position.z);
        }
    }
    
    
}
