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
    [SerializeField] int m_nHP = 10;

    [Range(5f, 20f)]
    [SerializeField] float m_fResetTime = 10f;
    float curTime = 0f;

    [SerializeField] BossPhase phase = BossPhase.Defense;

    public BossPhase SetPhase(BossPhase bossPhase) => phase = bossPhase;

    [HideInInspector]
    public BrickGenerator brickGenerator;
    public System.Action<BossPhase> OnPhaseAlarm;
    public System.Action OnBossDeath;

    public bool DeathCheck(int _HP)
    {
        if(_HP <= 0)
        {
            OnBossDeath?.Invoke();
            return true;
        }
        return false;
    }
    public void AppendHP(int hp)
    {
        m_nHP += hp;
        BossHpPointBar.OnAddPoint(hp);
        DeathCheck(m_nHP);
    }
    public void TakeDamage(int damage) 
    { 
        m_nHP -= damage;
        BossHpPointBar.OnAddPoint(-damage);
        Debug.Log("Current HP : " + m_nHP);
        DeathCheck(m_nHP);
    }

    protected abstract void InitPatterns();
    protected abstract void BossAlarm(BossPhase bossPhase);
    protected abstract void BossDead();

    private void Awake()
    {
        InitPatterns();
        OnPhaseAlarm = BossAlarm;
        OnBossDeath = BossDead;
        BossHpPointBar.SetPointCount(m_nHP);
    }
   

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
            if (phase == BossPhase.Defense)
            {
                curTime -= Time.deltaTime;
                if (curTime < 0)
                {
                    if (phase == BossPhase.Defense)
                        phase = BossPhase.Attack;

                    OnPhaseAlarm(phase);

                    curTime = m_fResetTime;
                }
            }
            yield return null;
        }
    }

}
