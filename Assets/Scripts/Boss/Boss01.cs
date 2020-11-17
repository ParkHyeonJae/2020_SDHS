using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Boss01 : Boss
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
                PaddleChanger.SetPaddle(PaddleMode.Freedom);
                brickGenerator.gameObject.SetActive(false);

                StartCoroutine(AttackLoop());
                break;
            case BossPhase.Defense:
                PaddleChanger.SetPaddle(PaddleMode.Limited);
                brickGenerator.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    IEnumerator AttackLoop()
    {
        foreach (var e in bossPatterns)
        {
            Debug.Log("=== 보스 공격 시작 ===");
            yield return StartCoroutine(e.Attack());
        }
        Debug.Log("=== 보스 공격 종료 ===");
        OnPhaseAlarm?.Invoke(SetPhase(BossPhase.Defense));
        yield return null;
    }

    protected override void BossDead()
    {
        Debug.Log("Boss01 Dead");
    }
}
