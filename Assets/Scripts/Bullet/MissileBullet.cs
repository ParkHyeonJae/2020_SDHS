using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBullet : Bullet
{
    private void OnEnable()
    {
        m_curTime = 0f;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (gameObject.activeInHierarchy)
        {
            m_curTime += Time.deltaTime;
            if (m_curTime >= m_destroyTime)
            {
                RemoveThisBullet();
            }
            Transform playerTrans = FindObjectOfType<PaddleController>().transform;

            transform.parent.localRotation = Quaternion.Euler(0, 0, 90);


            float angle = Mathf.Atan2(playerTrans.position.y - transform.position.y
                , playerTrans.position.x - transform.position.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angle);
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
        else if (coll.transform.CompareTag("Wall"))
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
