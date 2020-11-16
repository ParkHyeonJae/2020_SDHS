using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[SelectionBase]
[DisallowMultipleComponent]
public abstract class Brick : MonoBehaviour
{
    private BrickSimulate m_brickSimulate;
    private Action OnDestroy;

    private objectPool brickPool = null;

    public void SetPool(objectPool brickPool)
    {
        this.brickPool = brickPool;
    }

    private void OnEnable()
    {
        m_brickSimulate = new BrickSimulate();
        OnDestroy = DestroyAction;
    }

    /// <summary>
    /// 벽돌이 사라졌을 때 일어다는 Action을 처리
    /// </summary>
    protected virtual void DestroyAction()
    {
        brickPool?.push(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (m_brickSimulate.Hit(coll))
        {
            OnDestroy?.Invoke();
        }
    }
}

public class BrickSimulate
{
    public bool Hit(Collision2D coll)
    {
        if (coll.transform.CompareTag("Ball"))
        {
            return true;
        }
        return false;
    }
}
