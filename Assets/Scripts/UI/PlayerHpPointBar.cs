using System;
using UnityEngine;

public class PlayerHpPointBar : PointBar
{
    [SerializeField] int MaxPoint = 3;
    public static Action<int> OnAddPoint;
    public void SetPointCount(int maxPoint) => m_MaxPoint = maxPoint;

    [SerializeField] bool m_bGodMode = false;
    private void Awake()
    {
        OnAddPoint = OnAddPointFunc;
        SetPointCount(MaxPoint);
    }
    public void OnAddPointFunc(int point)
    {
        if (m_bGodMode == true)
            return;
        AddPoint(point);
        if (IsDead())
            GameSystem.Instance.OnGameOver?.Invoke();
        CameraShake.OnShake(0.5f, 0.5f);
    }


    [ContextMenu("TEST_PLAYER_POINT_BAR")]
    public void TEST_PLAYER_POINT_BAR()
    {
        OnAddPoint(-1);
    }
}
