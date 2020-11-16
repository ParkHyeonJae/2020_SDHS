using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.tag)
    //}
    //
    // Start is called before the first frame update
    void Start()
    {
        Vector3 BallVec = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(1f, 0, 0);
        }
        if(Input.GetKey(KeyCode.Space))
        {
            transform.position += new Vector3(0, 0.01f, 0);
        }
    }
}
