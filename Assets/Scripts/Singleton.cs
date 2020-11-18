using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Singleton<T> where T : class 
{
    protected static T instance = null;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = System.Activator.CreateInstance(typeof(T)) as T;
            }
            return instance;
        }
    }
}


public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance = null;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;

                if (instance == null)
                {
                    instance = new GameObject("@" + typeof(T).ToString()
                        , typeof(T)).AddComponent<T>();
                }
            }
            return instance;
        }
    }
    public virtual void Init() { }
    public virtual void Destroy() { Destroy(this); }
}

public class SingletonM<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance
    {
        get
        {
            if (mInstnace == null)
            {
                mInstnace = FindObjectOfType<T>() as T;

                if (mInstnace == null)
                {
                    mInstnace = new GameObject(typeof(T).ToString(), typeof(T)) as T;
                }
                //DontDestroyOnLoad(mInstnace);
            }
            return mInstnace;
        }
    }
    private static T mInstnace;
}