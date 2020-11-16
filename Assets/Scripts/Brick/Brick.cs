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
    protected virtual void DestroyAction()
    {
        brickPool?.push(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
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
