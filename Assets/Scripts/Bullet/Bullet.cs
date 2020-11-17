using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    protected objectPool pool;
    [Range(0.5f, 5.0f)]
    [SerializeField] protected float m_speed = 2f;

    [Range(0.5f, 20.0f)]
    [SerializeField] protected float m_destroyTime = 10f;
    protected float m_curTime = 0f;


    public void SetPool(objectPool pool) => this.pool = pool;

}
