using System.Collections;
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

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.CompareTag("Paddle"))
        {
            PlayerHpPointBar.OnAddPoint(-1);

            RemoveThisBullet();
        }
    }

    public void RemoveThisBullet()
    {
        Debug.Assert(pool != null, "NullReference");
        pool.push(gameObject);
    }
}
