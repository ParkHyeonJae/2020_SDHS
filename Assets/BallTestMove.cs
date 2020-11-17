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
            rigidbody2D.velocity = Vector2.ClampMagnitude(rigidbody2D.velocity, MaxVelocity);
            yield return null;
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.CompareTag("Brick"))
        {
            rigidbody2D.AddForce(new Vector2(0, speed * -1f), ForceMode2D.Impulse);
        }
        else if (coll.transform.CompareTag("Paddle"))
        {
            rigidbody2D.AddForce(new Vector2(PaddleController.dirVelocity.normalized.x * 5f, speed), ForceMode2D.Impulse);
        }
    }
}
