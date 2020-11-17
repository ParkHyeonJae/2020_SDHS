using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public enum PrefabType
{
    BulletStorage,
    NormalBullet01,
    NormalBullet02,
    MissileBullet01
}

[System.Serializable]
public struct PrefabTable
{
    public GameObject Prefabs;
    public PrefabType prefabType;
}


public class Prefabs : MonoSingleton<Prefabs>
{
    [SerializeField] List<PrefabTable> prefabs;

    public bool m_bIsInit { get; private set; } = false;

    private Dictionary<PrefabType, GameObject> PrefabDic;

    public Dictionary<PrefabType, GameObject> GetPrefabDictionary() => PrefabDic;

    public GameObject GetObject(PrefabType type)
    {
        if (!m_bIsInit)
            m_bIsInit = InitPrefabs();
        if (GetPrefabDictionary().ContainsKey(type))
            return GetPrefabDictionary()[type];

        return null;
    }
    public bool InitPrefabs()
    {
        PrefabDic = new Dictionary<PrefabType, GameObject>();
        prefabs.ForEach(e => { 
            PrefabDic.Add(e.prefabType, e.Prefabs);
        });
        return true;
    }
}
