using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public Vector3 balckPos;
    public Vector3 whitePos;

    public float speedTime;

    private GameObject blackCoin;
    private GameObject whiteCoin;
    private GameObject striker;

    void Awake()
    {
        blackCoin = GameObject.FindGameObjectWithTag("BlackCoin");
        whiteCoin = GameObject.FindGameObjectWithTag("WhiteCoin");
        striker = GameObject.FindGameObjectWithTag("Striker");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Queen" )
        {
           // StartCoroutine(BlackPos());
            Destroy(collider.gameObject);

        }
        if (collider.gameObject.tag == "WhiteCoin")
        {
            //StartCoroutine(WhitePos());
            Destroy(collider.gameObject);
            //collider.transform.position = whitePos;//Vector3.Lerp(collider.transform.position, whitePos, speedTime * Time.deltaTime);
            ScoreManager.instance.AddScoreWhite();
        }
        if (collider.gameObject.tag == "BlackCoin")
        {
            //StartCoroutine(BlackPos());
            Destroy(collider.gameObject);
            //collider.transform.position = balckPos; //Vector3.Lerp(collider.transform.position, whitePos, speedTime * Time.deltaTime);
            ScoreManager.instance.AddScoreBlack();
        }
        /*if (collider.gameObject.tag == "Striker")
        {
            striker.transform.position = new Vector3(0, -1.6f, -.2f);

        }*/
    }

   /* IEnumerator BlackPos()
    {
        Debug.Log("Coroutinstart");
        blackCoin.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        blackCoin.GetComponent<SpriteRenderer>().color = new Color(190, 120, 77, 255);
        yield return new  WaitForSeconds(1);
        blackCoin.transform.position = balckPos;

    }

    IEnumerator WhitePos()
    {
        Debug.Log("Coroutinstart");
        whiteCoin.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        whiteCoin.GetComponent<SpriteRenderer>().color = new Color(190, 120, 77, 255);
        yield return new WaitForSeconds(1);
        blackCoin.transform.position = whitePos;

    }*/
}
