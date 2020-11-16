using System.Collections;
using System.Collections.Generic;
using InGame.Manager;
using UnityEngine;

public abstract class Boss : MonoBehaviour
{
    [SerializeField] float m_fHP = 10f;

    [Range(5f, 20f)]
    [SerializeField] float m_fResetTime = 10f;
    private Timer m_timer;
    private void OnEnable()
    {

        m_timer = new Timer(m_fResetTime, true);

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
