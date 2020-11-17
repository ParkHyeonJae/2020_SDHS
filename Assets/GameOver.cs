using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject GameOverUI = null;
    private void OnEnable()
    {
        Debug.Assert(GameOverUI != null, "NullReference");
        GameSystem.Instance.OnGameOver = () =>
        {
            GameOverUI.SetActive(true);
            Time.timeScale = 0.0f;
            Debug.Log("GameOver");
        };

    }

    public void _onClickRestartBtn()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
