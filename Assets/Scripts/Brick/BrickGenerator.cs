﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
public class BrickGenerator : MonoBehaviour
{
    [Tooltip("NormalBrick을 생성할 Prefabs")]
    [SerializeField] GameObject m_oNormalBrickPrefabs = null;
    [Tooltip("BossHeartBrick을 생성할 Prefabs")]
    [SerializeField] GameObject m_oBossHeartBrickPrefabs = null;
    [Tooltip("처음 Brick 을 생성할 기준점")]
    [SerializeField] Transform m_startGeneratePosition = null;
    [Tooltip("가로 폭 제한")]
    [SerializeField] int m_nRowClamp = 5;
    [Tooltip("Brick 사이 간의 거리")]
    [SerializeField] float m_fSpacing = 5.0f;

    [Tooltip("Brick 생성 개수")]
    [SerializeField] int m_nSpawnCount = 20;


    private objectPool brickPool;
    

    private GameObject _bossBrick = null;
    public bool isInitalized = false;
    private void Awake()
    {
        if (isInitalized)
            return;
        Debug.Assert(m_oNormalBrickPrefabs != null, "Nullreference");
        Debug.Assert(m_oBossHeartBrickPrefabs != null, "Nullreference");

        Debug.Log("1111111111111");
        brickPool = new objectPool(m_oNormalBrickPrefabs, m_nSpawnCount, transform);
        isInitalized = true;
    }

    private void OnEnable() => ActiveOn();
    private void OnDisable() => ActiveOff();

    private void ActiveOn()
    {
        _bossBrick = null;

        int groundHeight = m_nSpawnCount / m_nRowClamp;
        int bossHeartHeight = Random.Range(groundHeight - 2, groundHeight);
        int bossHeartWidth = Random.Range(0, m_nRowClamp);
        int row;
        int height;
        for (int i = 0; i < m_nSpawnCount; i++)
        {
            row = i % m_nRowClamp;
            height = i / m_nRowClamp;

            if (height.Equals(bossHeartHeight) && row.Equals(bossHeartWidth))
            {
                _bossBrick = MonoBehaviour.Instantiate(m_oBossHeartBrickPrefabs, transform);
                SetBrickPosition(_bossBrick, m_startGeneratePosition.position, row, height, m_fSpacing);
                continue;
            }

            GameObject _obj = brickPool.pop();

            if (_obj.TryGetComponent(out Brick brick)) { brick.SetPool(brickPool); }
            else Debug.LogError("Polling Object Not Found");

            SetBrickPosition(_obj, m_startGeneratePosition.position, row, height, m_fSpacing);
        }
    }

    private void ActiveOff()
    {
        brickPool.reset();
        if (_bossBrick == null)
            return;
        if (_bossBrick.TryGetComponent(out Brick brick))
        {
            Destroy(_bossBrick);
        }
        else Debug.LogError("brickPool Brick Component Not Found");
    }

    public void Rebuild()
    {
        ActiveOff();
        ActiveOn();
    }
    private void SetBrickPosition(GameObject target,  Vector3 startPosition, int row, int height, float spacing)
    {
        Debug.Log("row * spacing : " + row * spacing);
        target.transform.position = new Vector3(
                startPosition.x + row * spacing
                , startPosition.y + height * spacing, 0);
    }
}
