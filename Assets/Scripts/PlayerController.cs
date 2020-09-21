using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 initPos;
    public float speed;
    public float speedTime = 0.5f;


    private GameObject ball1;
    private GameObject ball2;
    private GameObject arrow;
    private GameObject circle;
    private GameObject strikerGrow;
    private GameObject striker;

    //calcDis
    private float currentdistance;
    private float safeSpace;
    private float shootPawer;

    [SerializeField]
    private float pawerSpeed = 5f;
    private float maxDistance = 1.5f;

    private Vector3 shootDirection;

    void Awake()
    {
        ball1 = GameObject.FindGameObjectWithTag("Ball1");
        ball2 = GameObject.FindGameObjectWithTag("Ball2");
        arrow = GameObject.FindGameObjectWithTag("Arrow");
        circle = GameObject.FindGameObjectWithTag("Circle");
        strikerGrow = GameObject.FindGameObjectWithTag("StrikerGlow");
        striker = GameObject.FindGameObjectWithTag("Striker");
    }

    private void OnMouseDrag()
    {
        currentdistance = Vector3.Distance(ball1.transform.position, transform.position);

        if (currentdistance <= maxDistance)
        {
            safeSpace = currentdistance;
        }
        else
        {
            safeSpace = maxDistance;
        }

        drowArrowAndPawerCircle();

        //calc pawer and dirction 
        shootPawer = Mathf.Abs(safeSpace) * pawerSpeed;

        Vector3 dimXY = ball1.transform.position - transform.position;
        //float difference = dimXY.magnitude;
        float difference = Vector3.Magnitude(ball1.transform.position - transform.position);
        ball2.transform.position = transform.position + (dimXY / difference * currentdistance * -1);
        ball2.transform.position = new Vector3(ball2.transform.position.x, ball2.transform.position.y, -0.5f);

        shootDirection = Vector3.Normalize(ball2.transform.position - transform.position);

    }

    private void OnMouseUp()
    {
        arrow.GetComponent<SpriteRenderer>().enabled = false;
        circle.GetComponent<SpriteRenderer>().enabled = false;

        Vector3 push = shootDirection * shootPawer;
        GetComponent<Rigidbody2D>().AddForce(push, ForceMode2D.Impulse);

        StartCoroutine(SrikerStaringPos());

        //SrikerStaringPos();
    }

    private void drowArrowAndPawerCircle()
    {
        //arrow.GetComponent<SpriteRenderer>().enabled = true;
        circle.GetComponent<SpriteRenderer>().enabled = true;
        //striker.GetComponent<CircleCollider2D>().enabled = true;

        if (currentdistance <= maxDistance)
        {
            arrow.transform.position = new Vector3((2 * transform.position.x) - ball1.transform.position.x, (2 * transform.position.y) - ball1.transform.position.y, -1.5f);

        }
        else
        {
            Vector3 dimXY = ball1.transform.position - transform.position;
            //float difference = dimXY.magnitude;
            float difference = Vector3.Magnitude(ball1.transform.position - transform.position);
            arrow.transform.position = transform.position + (dimXY / difference * maxDistance * -1);
            arrow.transform.position = new Vector3(arrow.transform.position.x, arrow.transform.position.y, -1.5f);
        }

        circle.transform.position = transform.position;
        Vector3 dir = ball1.transform.position - transform.position;
        float rot;
        if (Vector3.Angle(dir, transform.forward) > 90)
        {
            rot = Vector3.Angle(dir, transform.right);
          
        }
        else
        {
            rot = Vector3.Angle(dir, transform.right) * -1;
          
        }

        arrow.transform.eulerAngles = new Vector3(0, 0, rot);


        float scaleX = Mathf.Log( safeSpace / 2, 2);
        float scaley = Mathf.Log( safeSpace / 2, 2);

        arrow.transform.localScale = new Vector3(1 + scaleX, 1 + scaley, 0.0001f);
        circle.transform.localScale = new Vector3(1 + scaleX, 1 + scaley, 0.0001f);

        strikerGrow.GetComponent<SpriteRenderer>().enabled = false;

        

    }


    IEnumerator SrikerStaringPos()
    {
        
        yield return new WaitForSeconds(4f);

       /* speed = striker.GetComponent<Rigidbody2D>().velocity.magnitude;
        if (speed < 0.2)
        {
            striker.GetComponent<CircleCollider2D>().enabled = false;
        }*/

        transform.position = initPos; //Vector3.Lerp(transform.position, initPos, speedTime * Time.deltaTime);
        strikerGrow.transform.position = initPos;
        strikerGrow.GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0 , 0 , 0);
        
    }


}
