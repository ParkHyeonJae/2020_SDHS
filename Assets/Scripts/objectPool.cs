using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class objectPool
{
    public Queue<GameObject> queue = new Queue<GameObject>();
    public List<GameObject> usedObject = new List<GameObject>();
    private int count = 0;
    private GameObject poolObject;
    private Transform parent;
    public objectPool(GameObject poolObject, int count)
    {
        this.poolObject = poolObject;
        this.count = count;

        Initalize(this.count);

    }
    public objectPool(GameObject poolObject, int count, Transform parent)
    {
        this.poolObject = poolObject;
        this.count = count;
        this.parent = parent;
        Initalize(this.count);

    }
    void Initalize(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject obj = MonoBehaviour.Instantiate(poolObject, parent);
            obj.SetActive(false);
            queue.Enqueue(obj);
        }
    }
    public void InitTransform(Transform _transform)
    {
        _transform.position = Vector3.zero;
        _transform.rotation = Quaternion.identity;
    }
    public void push(GameObject obj) {
        InitTransform(obj.transform);
        obj.SetActive(false);
        queue.Enqueue(obj);
        usedObject.Remove(obj);
    }

    GameObject obj = null;
    public GameObject pop() {
        if (queue.Count <= 0) Initalize(this.count);
        (obj = queue.Dequeue()).SetActive(true);
        usedObject.Add(obj);
        return obj; }

    public void reset()
    {
        usedObject.ForEach(e => {
            InitTransform(e.transform);
            obj.SetActive(false);
            queue.Enqueue(e);
        });
        usedObject.Clear();
    }
    public void Print()
    {
        foreach (var v in queue)
        {
            Debug.Log(v.name);
        }
    }
}
