using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private BrickSimulate m_brickSimulate;
    private Action OnDestroy;

    private void OnEnable()
    {
        m_brickSimulate = new BrickSimulate();
        OnDestroy = DestroyAction;
    }
    private void DestroyAction()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("충돌 테스트");
        if (m_brickSimulate.Hit(coll))
        {
            OnDestroy?.Invoke();
        }
    }
}

public class BrickSimulate
{
    public bool Hit(Collider2D coll)
    {
        if (coll.CompareTag("Ball"))
        {
            return true;
        }
        return false;
    }
}
