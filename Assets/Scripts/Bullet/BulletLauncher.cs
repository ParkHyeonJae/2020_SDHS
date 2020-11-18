using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletLauncher
{
	public bool m_bIsFinish = false;
    
	public abstract void LauncherInit();
	public abstract void LauncherUpdate();
}

public class CircleBulletLancher : BulletLauncher
{
    private objectPool normalBullet01 = null;
    private Boss boss = null;
    public CircleBulletLancher(Boss boss)
    {
        this.boss = boss;
        this.normalBullet01 = boss.normalBullet01;
    }

    public override void LauncherInit()
    {
        m_bIsFinish = false;
        Debug.Assert(boss != null, "NullRefernce");
        Debug.Assert(normalBullet01 != null, "NullRefernce");
    }

    public override void LauncherUpdate()
    {
        for (float i = 0; i < 360f; i += 45f)
        {
            GameObject _bullet = normalBullet01.pop();
            _bullet.GetComponent<Bullet>().SetPool(normalBullet01);
            _bullet.transform.position = Camera.main.ScreenToWorldPoint(boss.transform.position) * new Vector2(1, 1);
            _bullet.transform.rotation = Quaternion.Euler(0, 0, i);
        }

        m_bIsFinish = true;
    }
}


public class MissileBulletLancher : BulletLauncher
{
    private objectPool missileBullet01 = null;
    private Boss boss = null;
    public MissileBulletLancher(Boss boss)
    {
        this.boss = boss;
        this.missileBullet01 = boss.missileBullet01;
    }

    public override void LauncherInit()
    {
        m_bIsFinish = false;
        Debug.Assert(boss != null, "NullRefernce");
        Debug.Assert(missileBullet01 != null, "NullRefernce");
    }

    public override void LauncherUpdate()
    {
        GameObject _bullet = missileBullet01.pop();
        _bullet.transform.GetChild(0).GetComponent<Bullet>().SetPool(missileBullet01);
        _bullet.transform.GetChild(0).position = Camera.main.ScreenToWorldPoint(boss.transform.position) * new Vector2(1, 1);

        m_bIsFinish = true;
    }
}