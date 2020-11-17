﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BossPattern
{
    IEnumerator Attack();
}

public class Pattern01 : BossPattern
{
    private Boss m_Boss;
    private CircleBulletLancher circleBulletLauncher;
    public Pattern01(Boss m_Boss)
    {
        this.m_Boss = m_Boss;
        circleBulletLauncher = new CircleBulletLancher(m_Boss);
    }

    public IEnumerator Attack()
    {
        for (int i = 0; i < 5; i++)
        {
            while (!circleBulletLauncher.m_bIsFinish)
            {
                circleBulletLauncher.LauncherUpdate();
                yield return null;
            }
            circleBulletLauncher.LauncherInit();
            yield return new WaitForSeconds(1.0f);
        }
        
    }
}
public class Pattern02 : BossPattern
{
    private Boss m_Boss;
    public Pattern02(Boss m_Boss)
    {
        this.m_Boss = m_Boss;
    }

    public IEnumerator Attack()
    {
        Debug.Log("Pattern2 시작");

        Debug.Log("공격4");
        CameraShake.OnShake(1f, 0.1f);
        yield return new WaitForSeconds(1.0f);
        Debug.Log("공격5");
        CameraShake.OnShake(1f, 0.1f);
        yield return new WaitForSeconds(1.0f);
        Debug.Log("공격6");
        CameraShake.OnShake(1f, 0.1f);
        yield return new WaitForSeconds(10.0f);
    }
}
