using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PaddleController : MonoBehaviour
{
    [Range(1.0f, 10.0f)]
    [SerializeField] float m_fSpeed = 2.0f;

    public static Vector3 dirVelocity { get; set; }

    private Rigidbody2D rigidbody2D;
    private PaddleMode lastedPaddle = PaddleMode.Limited;

    private void OnEnable()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(Loop());
    }
    IEnumerator Loop()
    {
        while (gameObject.activeInHierarchy)
        {
            if (PaddleChanger.paddleMode != lastedPaddle)
            {
                PaddleChanger.OnChangePaddle(PaddleChanger.paddleMode);
                lastedPaddle = PaddleChanger.paddleMode;
            }
            switch (PaddleChanger.paddleMode)
            {
                case PaddleMode.Limited:
                    dirVelocity = Vector3.right * Input.GetAxisRaw("Horizontal") * m_fSpeed;
                    rigidbody2D.velocity = dirVelocity;
                    break;
                case PaddleMode.Freedom:
                    dirVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * m_fSpeed;
                    rigidbody2D.velocity = dirVelocity;
                    break;
                default:
                    break;
            }
            yield return null;
        }
        yield return null;
    }
}
