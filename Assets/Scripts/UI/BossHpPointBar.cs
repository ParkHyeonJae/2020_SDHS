using System;

public class BossHpPointBar : PointBar
{
    public static Action<int> OnAddPoint;

    public static void SetPointCount(int maxPoint) => m_MaxPoint = maxPoint;

    private void Awake()
    {
        OnAddPoint = AddPoint;
    }
}
