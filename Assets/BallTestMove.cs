using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTestMove : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float MaxVelocity = 5f;

    private BallSimulate ballSimulate;

    private void OnEnable()
    {
        ballSimulate = new BallSimulate(speed, MaxVelocity);
        ballSimulate.InitBall(GetComponent<CircleCollider2D>()
            , GetComponent<Rigidbody2D>());
        StartCoroutine(EUpdate());
    }
    IEnumerator EUpdate()
    {
        while (gameObject.activeInHierarchy)
        {
            ballSimulate.UpdateBall();
            yield return null;
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        ballSimulate.HitPaddleTrigger(coll);
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        ballSimulate.Hit(coll);
    }
}

public class BallSimulate
{
    private Rigidbody2D rd;
    private CircleCollider2D circleCollider2D;

    private float speed;
    private float MaxVelocity;

    public BallSimulate(float speed, float MaxVelocity)
    {
        this.speed = speed;
        this.MaxVelocity = MaxVelocity;
    }

    public void InitBall(CircleCollider2D circleCollider2D, Rigidbody2D rigidbody2D)
    {
        this.circleCollider2D = circleCollider2D;
        circleCollider2D.isTrigger = true;

        rd = rigidbody2D;
        rd.velocity = new Vector2(Random.insideUnitSphere.x, -speed);
    }

    public void UpdateBall()
    {
        rd.velocity = Vector2.ClampMagnitude(rd.velocity, MaxVelocity);

        if (rd.velocity.magnitude < 1)
            rd.velocity = new Vector2(speed, speed);
    }

    public void HitPaddleTrigger(Collider2D coll)
    {
        if (!circleCollider2D.isTrigger)
            return;
        if (coll.CompareTag("Paddle"))
        {
            circleCollider2D.isTrigger = false;
        }
    }


    public void Hit(Collision2D coll)
    {
        if (coll.transform.CompareTag("Brick"))
            rd.AddForce(new Vector2(0, speed * -1f), ForceMode2D.Impulse);
        else if (coll.transform.CompareTag("Paddle"))
            rd.AddForce(new Vector2(PaddleController.dirVelocity.normalized.x * 5f, speed), ForceMode2D.Impulse);
        else
            rd.AddForce(new Vector2(speed, speed), ForceMode2D.Force);
    }
}