using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss : MonoBehaviour
{
    [SerializeField] float m_fHP = 10f;

    private void OnEnable()
    {
        StartCoroutine(EBossLoop());
    }
    IEnumerator EBossLoop()
    {
        while(gameObject.activeInHierarchy)
        {


            yield return null;
        }
    }
}
