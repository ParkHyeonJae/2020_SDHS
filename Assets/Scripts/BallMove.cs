using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    private void ontriggerenter2d(Collision2D collision)
    {
        if (collision.gameObject.tag == "Brick")
        {

        }
    }
    // Start is called before the first frame update

    void Start()
    {
        Transform tr = GetComponent<Transform>();
        Vector3 BallVec = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        RotateFire();
    }
    void RotateFire()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(0, 0, -1f);
        }
        if (Input.GetKey(KeyCode.X))
        {
            transform.Rotate(0, 0, 1f);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = transform.position + transform.up * 0.01f;
        }
    }
}
