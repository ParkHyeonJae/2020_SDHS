using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
public class BrickGenerator : MonoBehaviour
{
    [SerializeField] GameObject m_oBrickPrefabs = null;
    [SerializeField] Transform m_startGeneratePosition = null;
    [SerializeField] int m_nRowClamp = 5;
    [SerializeField] float m_fSpacing = 5.0f;


    [SerializeField] int m_nSpawnCount = 20;

    private objectPool brickPool;

    private void OnEnable()
    {
        Debug.Assert(m_oBrickPrefabs != null, "Nullreference");

        brickPool = new objectPool(m_oBrickPrefabs, m_nSpawnCount);

        for (int i = 0; i < m_nSpawnCount; i++) 
        {
            GameObject _obj = brickPool.pop();
            int row = i % m_nRowClamp;
            int height = i / m_nRowClamp;
            _obj.transform.position = new Vector3(
                m_startGeneratePosition.position.x + row * m_fSpacing
                , m_startGeneratePosition.position.y + height * m_fSpacing, 0);
        }
    }
}
