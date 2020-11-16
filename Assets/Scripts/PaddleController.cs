using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [Range(1.0f, 10.0f)]
    [SerializeField] float m_fSpeed = 2.0f;

    public static Vector3 dirVelocity { get; set; }

    private Rigidbody2D rigidbody2D;

    private void OnEnable()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(Loop());
    }
    IEnumerator Loop()
    {
        while (gameObject.activeInHierarchy)
        {
            dirVelocity = Vector3.right * Input.GetAxisRaw("Horizontal") * m_fSpeed;
            rigidbody2D.velocity = dirVelocity;
            yield return null;
        }
        yield return null;
    }
}
