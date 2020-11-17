using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public enum PaddleMode
{
    Limited,
    Freedom
}

public class PaddleChanger : MonoBehaviour
{
    public static PaddleMode paddleMode = PaddleMode.Limited;

    [SerializeField] PaddleController m_limitedPaddle = null;
    [SerializeField] PaddleController m_freedomPaddle = null;

    public static Action<PaddleMode> OnChangePaddle;

    private void Awake()
    {
        OnChangePaddle = ChangePaddle;
        paddleMode = PaddleMode.Limited;
        ChangePaddle(paddleMode);
    }

    public static void SetPaddle(PaddleMode _paddleMode) => paddleMode = _paddleMode;

    public void ChangePaddle(PaddleMode paddleMode)
    {
        switch (paddleMode)
        {
            case PaddleMode.Limited:
                m_limitedPaddle.gameObject.SetActive(true);
                m_freedomPaddle.gameObject.SetActive(false);
                break;
            case PaddleMode.Freedom:
                m_freedomPaddle.gameObject.SetActive(true);
                m_limitedPaddle.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }


    // TEST CODE
    [ContextMenu("TEST_CHANGED_LIMITED_PADDLE")]
    public void TEST_CHANGED_LIMITED_PADDLE()
    {
        //ChangePaddle(PaddleMode.Limited);
        paddleMode = PaddleMode.Limited;
    }

    [ContextMenu("TEST_CHANGED_FREEDOM_PADDLE")]
    public void TEST_CHANGED_FREEDOM_PADDLE()
    {
        //ChangePaddle(PaddleMode.Freedom);
        paddleMode = PaddleMode.Freedom;
    }
    
    // TEST CODE
}
