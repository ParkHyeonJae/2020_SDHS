using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Boss07 : Boss
{
    [SerializeField] List<BossPattern> bossPatterns = new List<BossPattern>();

    protected override void InitPatterns()
    {
        bossPatterns.Add(new Pattern01(this));
        bossPatterns.Add(new Pattern02(this));
        
    }

    protected override void BossAlarm(BossPhase bossPhase)
    {
        switch (bossPhase)
        {
            case BossPhase.Attack:
                GamePlayLine.SetActive(false);
                PaddleChanger.Instance.SetPaddle(PaddleMode.Freedom);
                if (BallObject != null)
                    ballPool.push(BallObject);
                brickGenerator.gameObject.SetActive(false);

                StartCoroutine(AttackLoop());
                break;
            case BossPhase.Defense:
                GamePlayLine.SetActive(true);
                PaddleChanger.Instance.SetPaddle(PaddleMode.Limited);

                SpawnBall();

                brickGenerator.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    IEnumerator AttackLoop()
    {
        StartCoroutine(BossMovement());

        foreach (var e in bossPatterns)
        {
            Debug.Log("=== 보스 공격 시작 ===");
            yield return StartCoroutine(e.Attack());
        }
        Debug.Log("=== 보스 공격 종료 ===");
        OnPhaseAlarm?.Invoke(SetPhase(BossPhase.Defense));
        yield return null;
    }

    IEnumerator BossMovement()
    {
        float[] pos = new float[] { 0 , -35, 35 };
        int i = 0;
        while (phase == BossPhase.Attack)
        {
            transform.localPosition = new Vector3(pos[i], transform.localPosition.y);
            i++;
            
            i %= pos.Length;
            yield return new WaitForSeconds(3f);
        }
    }

    protected override void BossDead()
    {
        base.BossDead();

        gameObject.SetActive(false);
        PlayerPrefs.SetInt("6", 1);
        Debug.Log("Boss06 Dead");
    }
}
