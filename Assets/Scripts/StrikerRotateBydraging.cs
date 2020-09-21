using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikerRotateBydraging : MonoBehaviour
{
    public float speed;

    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * speed * Mathf.Deg2Rad;
        transform.Rotate(Vector3.forward , rotX );
    }

}
