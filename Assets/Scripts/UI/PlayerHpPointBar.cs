using System;
using UnityEngine;

public class PlayerHpPointBar : PointBar
{
    [SerializeField] int MaxPoint = 3;
    public static Action<int> OnAddPoint;
    public static void SetPointCount(int maxPoint) => m_MaxPoint = maxPoint;

    private void Awake()
    {
        OnAddPoint = OnAddPointFunc;
        SetPointCount(MaxPoint);
    }
    public void OnAddPointFunc(int point)
    {
        AddPoint(point);
        CameraShake.OnShake(0.5f, 0.5f);
    }


    [ContextMenu("TEST_PLAYER_POINT_BAR")]
    public void TEST_PLAYER_POINT_BAR()
    {
        OnAddPoint(-1);
    }
}
