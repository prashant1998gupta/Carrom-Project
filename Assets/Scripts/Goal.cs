using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Queen" )
        {
            Destroy(collider.gameObject);
            
        }
        if(collider.gameObject.tag == "WhiteCoin")
        {
            Destroy(collider.gameObject);
            ScoreManager.instance.AddScoreWhite();
        }
        if (collider.gameObject.tag == "BlackCoin")
        {
            Destroy(collider.gameObject);
            ScoreManager.instance.AddScoreBlack();
        }
        /*if (collider.gameObject.tag == "Striker")
        {
            gameObject.transform.position = new Vector3(0, -1.6f, -.2f);

        }*/
    }
}
