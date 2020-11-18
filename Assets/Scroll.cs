using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [Range(0.01f,2.0f)]
    [SerializeField] float m_speed = 0.25f;
    private MeshRenderer renderer;
    private void OnEnable()
    {
        renderer = GetComponent<MeshRenderer>();
        StartCoroutine(Scrolling());
    }
    IEnumerator Scrolling()
    {
        while(gameObject.activeInHierarchy)
        {
            Vector2 offset = new Vector2(0, Time.deltaTime * m_speed);
            renderer.material.mainTextureOffset += offset;

            yield return null;
        }
    }
}
