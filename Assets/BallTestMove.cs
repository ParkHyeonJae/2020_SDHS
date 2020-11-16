using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTestMove : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    private Rigidbody2D rigidbody2D;


    private void OnEnable()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(Random.insideUnitSphere.x, speed);

        StartCoroutine(EUpdate());
    }
    IEnumerator EUpdate()
    {
        while (gameObject.activeInHierarchy)
        {
            yield return null;
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.CompareTag("Brick"))
        {
            rigidbody2D.AddForce(new Vector2(0, -1f));
        }
        else if (coll.transform.CompareTag("Paddle"))
        {
            rigidbody2D.AddForce(new Vector2(PaddleController.dirVelocity.x * 20f, -1f));
            //rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x * (PaddleController.dirVelocity.x * 200f), rigidbody2D.velocity.y * -1f) * 1.005f;
        }
        rigidbody2D.AddForce(new Vector2(0.5f, 0.5f), ForceMode2D.Impulse);
    }
}
