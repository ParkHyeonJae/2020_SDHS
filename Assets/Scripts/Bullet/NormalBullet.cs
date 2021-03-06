﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : Bullet
{
    private void OnEnable()
    {
        m_curTime = 0f;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while(gameObject.activeInHierarchy)
        {
            m_curTime += Time.deltaTime;
            if (m_curTime >= m_destroyTime)
            {
                RemoveThisBullet();
            }
            transform.Translate(Vector2.right * m_speed * Time.deltaTime, Space.Self);
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.CompareTag("Player"))
        {
            PlayerHpPointBar.OnAddPoint(-1);

            RemoveThisBullet();
        }
        else if(coll.transform.CompareTag("Wall"))
        {
            RemoveThisBullet();
        }
    }

    public void RemoveThisBullet()
    {
        Debug.Assert(pool != null, "NullReference");
        pool.push(gameObject);
    }
}
