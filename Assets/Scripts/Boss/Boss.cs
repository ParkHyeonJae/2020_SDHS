using System.Collections;
using System.Collections.Generic;
using InGame.Manager;
using UnityEngine;

[System.Serializable]
public enum BossPhase
{
    Attack,
    Defense
}

public abstract class Boss : MonoBehaviour
{
    [SerializeField] float m_fHP = 10f;

    [Range(5f, 20f)]
    [SerializeField] float m_fResetTime = 10f;
    float curTime = 0f;

    [SerializeField] BossPhase phase = BossPhase.Defense;

    protected BrickGenerator brickGenerator;
    private System.Action<BossPhase> OnPhaseAlarm;

    private void Awake()
    {
        OnPhaseAlarm = BossAlarm;
    }
    protected abstract void BossAlarm(BossPhase bossPhase);

    private void OnEnable()
    {
        curTime = m_fResetTime;
        brickGenerator = FindObjectOfType<BrickGenerator>();
        StartCoroutine(EBossLoop());
    }
    IEnumerator EBossLoop()
    {
        while(gameObject.activeInHierarchy)
        {
            curTime -= Time.deltaTime;
            if (curTime < 0)
            {
                if (phase == BossPhase.Attack)
                    phase = BossPhase.Defense;
                else phase = BossPhase.Attack;

                OnPhaseAlarm(phase);

                curTime = m_fResetTime;
            }
            yield return null;
        }
    }

}
