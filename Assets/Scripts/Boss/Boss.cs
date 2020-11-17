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
    [SerializeField] UnityEngine.UI.Image CoolTimeImg = null;
    [SerializeField] GameObject BallPrefabs = null;
    public objectPool ballPool = null;
    protected GameObject BallObject = null;

    [SerializeField] protected BossPhase phase = BossPhase.Defense;

    public BossPhase SetPhase(BossPhase bossPhase) => phase = bossPhase;

    [HideInInspector]
    public BrickGenerator brickGenerator;
    public System.Action<BossPhase> OnPhaseAlarm;
    public System.Action OnBossDeath;

    protected BossSystem bossSystem;

    public void SetBossSystem(BossSystem bossSystem) => this.bossSystem = bossSystem;

    [SerializeField] protected GameObject GamePlayLine = null;


    //BOSS BULLET POOL OBJECTS
    public objectPool normalBullet01 = null;
    public objectPool normalBullet02 = null;
    public objectPool missileBullet01 = null;

    //BOSS BULLET POOL OBJECTS

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
    protected virtual void BossDead()
    {
        ballPool.reset();
        bossSystem.SpawnBoss();
    }

    private void Awake()
    {
        OnPhaseAlarm = BossAlarm;
        OnBossDeath = BossDead;

        ballPool = new objectPool(BallPrefabs, 5);

        Prefabs _prefabs = Prefabs.Instance;
        Transform _bulletStorage = _prefabs.GetObject(PrefabType.BulletStorage).transform;
        Debug.Assert(_bulletStorage != null, "NullReference");

        normalBullet01 = new objectPool(_prefabs.GetObject(PrefabType.NormalBullet01), 20, _bulletStorage);
        normalBullet02 = new objectPool(_prefabs.GetObject(PrefabType.NormalBullet02), 10, _bulletStorage);
        missileBullet01 = new objectPool(_prefabs.GetObject(PrefabType.MissileBullet01), 10, _bulletStorage);

        Debug.Assert(GamePlayLine != null, "NullReference");
        Debug.Assert(CoolTimeImg != null, "NullReference");
        Debug.Assert(BallPrefabs != null, "NullReference");

    }
   
    public void InitCoolTime() => curTime = m_fResetTime;

    private void OnEnable()
    {
        InitPatterns();
        InitCoolTime();
        //BossHpPointBar.OnSetPoint(m_nHP);

        brickGenerator = FindObjectOfType<BrickGenerator>();
        StartCoroutine(EBossLoop());

        SpawnBall();
    }

    public void SpawnBall()
    {
        BallObject = ballPool.pop();
        Vector3 Pos = Camera.main.ScreenToWorldPoint(transform.position) * new Vector2(1, 1);
        BallObject.transform.position = Pos;
    }

    IEnumerator EBossLoop()
    {
        while(gameObject.activeInHierarchy)
        {
            if (phase == BossPhase.Defense)
            {
                curTime -= Time.deltaTime;
                CoolTimeImg.fillAmount = curTime / m_fResetTime;

                if (curTime < 0)
                {
                    if (phase == BossPhase.Defense)
                        phase = BossPhase.Attack;

                    OnPhaseAlarm(phase);

                    InitCoolTime();
                }
            }
            yield return null;
        }
    }

}
