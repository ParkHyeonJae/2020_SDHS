using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [Range(1.0f, 5.0f)]
    [SerializeField] float m_fSpeed = 2.0f;


    private void OnEnable()
    {
        StartCoroutine(Loop());
    }


    IEnumerator Loop()
    {
        while (gameObject.activeInHierarchy)
        {
            transform.position += Vector3.right * Input.GetAxisRaw("Horizontal") * Time.deltaTime * m_fSpeed;
            yield return null;
        }
        yield return null;
    }
}
