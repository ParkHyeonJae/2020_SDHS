using System.Collections;
using System.Collections.Generic;
using InGame.Manager;
using UnityEngine;

public abstract class Boss : MonoBehaviour
{
    [SerializeField] float m_fHP = 10f;

    [Range(5f, 20f)]
    [SerializeField] float m_fResetTime = 10f;

    [SerializeField] UnityEngine.UI.Image m_phaseTimeImage = null;
    private Timer m_timer;
    private void OnEnable()
    {
        Debug.Assert(m_phaseTimeImage != null, "NullReference");

        m_timer = new Timer(m_fResetTime, true);

        StartCoroutine(EBossLoop());
    }
    IEnumerator EBossLoop()
    {
        while(gameObject.activeInHierarchy)
        {
            //int curTime = (int)m_timer.Operate();
            //Debug.Log(curTime);
            //m_phaseTimeImage.fillAmount = 1.0f / curTime;


            if (m_timer.LimitOperate())
            {

            }
            

            yield return null;
        }
    }
}
