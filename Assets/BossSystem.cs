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
        bosses.ForEach(e => e.SetBossSystem(this));

        SpawnBoss();
    }

    public void SpawnBoss()
    {
        bosses[sequence++].gameObject.SetActive(true);
        sequence %= bosses.Count;
    }
}
