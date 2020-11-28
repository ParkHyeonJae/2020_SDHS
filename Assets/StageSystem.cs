using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum SpawnBossType
{
    LUST,
    GLUTTONY,
    ENVY,
    GREED,
    PRIDE,
    SLOTH,
    WRATH,
}

[System.Serializable]
public class Stage
{
    public UnityEngine.UI.Image imageUI;
    public SpawnBossType spawnBoss;
    public bool isClear;
    public Sprite Open;
    public Sprite Close;
}

public class StageSystem : MonoBehaviour
{
    [SerializeField] List<Stage> m_stageLists;

    int m_nlastestStageOpen = 0;
    int m_nMaxStageCount = 0;

    public static SpawnBossType spawnBossType = SpawnBossType.LUST;

    private void Start()
    {
        m_nMaxStageCount = m_stageLists.Count;
        
        for (int i = 0; i < m_nMaxStageCount; i++)
        {
            if (!PlayerPrefs.HasKey(i.ToString()))
            {
                int result = 0;
                if (i == 0)
                    result = 1;
                PlayerPrefs.SetInt(i.ToString(), result);
            }

            m_stageLists[i].isClear = (PlayerPrefs.GetInt(i.ToString()) == 1) ? true : false;

            if (m_stageLists[i].isClear)
                m_stageLists[i].imageUI.sprite = m_stageLists[i].Open;
            else m_stageLists[i].imageUI.sprite = m_stageLists[i].Close;
        }
    }

    public void _onClickBossButton(int BossIndex)
    {
        spawnBossType = (SpawnBossType)BossIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
    }
}
