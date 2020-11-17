using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTestMove : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    private Rigidbody2D rigidbody2D;
    [SerializeField] float MaxVelocity = 5f;

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
            if (rigidbody2D.velocity.x >= MaxVelocity)
                rigidbody2D.velocity = new Vector2(MaxVelocity, rigidbody2D.velocity.y);
            else if (rigidbody2D.velocity.y >= MaxVelocity)
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, MaxVelocity);
            yield return null;
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.CompareTag("Brick"))
        {
            rigidbody2D.AddForce(new Vector2(0, -1f * speed));
        }
        else if (coll.transform.CompareTag("Paddle"))
        {
            rigidbody2D.AddForce(new Vector2(PaddleController.dirVelocity.x * 10f, -1f * speed));
        }
        //rigidbody2D.AddForce(new Vector2(1.0f, 1.0f), ForceMode2D.Impulse);
    }
}
