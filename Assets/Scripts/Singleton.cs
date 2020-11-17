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