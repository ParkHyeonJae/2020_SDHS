using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossSystem : MonoBehaviour
{
    public List<Boss> bosses;
    public int sequence = 0;

    private void Start()
    {
        SoundManager.Instance.PlayLoopSound("BGM");
        bosses.ForEach(e => e.SetBossSystem(this));

        SpawnBoss();
    }

    public void SpawnBoss()
    {
        
        bosses[(int)StageSystem.spawnBossType].gameObject.SetActive(true);
        sequence++;
        sequence %= bosses.Count;
    }
}
