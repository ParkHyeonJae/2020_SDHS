using System;

public class BossHpPointBar : PointBar
{
    public static Action<int> OnAddPoint;
    public static Action<int> OnSetPoint;
    public static Action InitalizeAll;
    public void SetPointCount(int maxPoint) => m_MaxPoint = maxPoint;


    private void Awake()
    {
        OnAddPoint = AddPoint;
        OnSetPoint = SetPointCount;
        InitalizeAll = InitalizeAllElement;
    }
}
