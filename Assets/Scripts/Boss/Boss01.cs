using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01 : Boss
{


    protected override void BossAlarm(BossPhase bossPhase)
    {
        switch (bossPhase)
        {
            case BossPhase.Attack:
                brickGenerator.gameObject.SetActive(false);

                break;
            case BossPhase.Defense:
                brickGenerator.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }
}
