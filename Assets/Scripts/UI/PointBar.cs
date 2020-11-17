using UnityEngine;

public abstract class PointBar : MonoBehaviour
{
    protected static int m_MaxPoint = 8;

    [SerializeField] int m_nCurPointCount = 0;

    [SerializeField] GameObject[] point_objects;

    public bool IsRemainActionPoint() => m_nCurPointCount > 0;
    // Call this Method, if you want to Control Action Point
    public void AddPoint(int amount)
    {
        m_nCurPointCount += amount;
        m_nCurPointCount = Mathf.Min(m_nCurPointCount, m_MaxPoint);
        m_nCurPointCount = Mathf.Max(m_nCurPointCount, 0);

        bool active = (amount > 0) ? true : false;

        if (active) point_objects[m_nCurPointCount - 1].SetActive(active);
        else point_objects[m_nCurPointCount].SetActive(active);
    }

    private void OnEnable() => Initialize();


    [ContextMenu("TEST_DECREASE")]
    public void TEST_DECREASE()
    {
        AddPoint(-1);
    }

    [ContextMenu("TEST_INCREASE")]
    public void TEST_INCREASE()
    {
        AddPoint(1);
    }

    public void Initialize()
    {
        m_nCurPointCount = m_MaxPoint;
    }
}
