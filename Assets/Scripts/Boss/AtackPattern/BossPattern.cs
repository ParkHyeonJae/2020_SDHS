using System.Collections;
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
    private MissileBulletLancher missileBulletLancher;
    public Pattern01(Boss m_Boss)
    {
        this.m_Boss = m_Boss;
        circleBulletLauncher = new CircleBulletLancher(m_Boss);
        missileBulletLancher = new MissileBulletLancher(m_Boss);
    }

    public IEnumerator Attack()
    {
        yield return new WaitForSeconds(2.0f);

        while (!missileBulletLancher.m_bIsFinish)
        {
            missileBulletLancher.LauncherUpdate();
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);


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
        yield return new WaitForSeconds(2.0f);
    }
}
public class Pattern02 : BossPattern
{
    private CircleBulletLancher circleBulletLauncher;
    private MissileBulletLancher missileBulletLancher;

    private Boss m_Boss;
    public Pattern02(Boss m_Boss)
    {
        this.m_Boss = m_Boss;
        circleBulletLauncher = new CircleBulletLancher(m_Boss);
        missileBulletLancher = new MissileBulletLancher(m_Boss);
    }

    public IEnumerator Attack()
    {
        yield return new WaitForSeconds(2.0f);
        for (int i = 0; i < 5; i++)
        {
            while (!circleBulletLauncher.m_bIsFinish)
            {
                circleBulletLauncher.LauncherUpdate();
                yield return null;
            }
            circleBulletLauncher.LauncherInit();
            yield return new WaitForSeconds(1.0f);

            
            while (!missileBulletLancher.m_bIsFinish)
            {
                missileBulletLancher.LauncherUpdate();
                yield return null;
            }
            missileBulletLancher.LauncherInit();
        }
        

        yield return new WaitForSeconds(1.0f);
    }
}
