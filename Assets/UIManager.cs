using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject Pause = null;
    private void OnEnable()
    {
        Debug.Assert(Pause != null, "NullReference");
        StartCoroutine(INPUT());
    }
    IEnumerator INPUT()
    {
        while(gameObject.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Pause.activeInHierarchy)
                    Pause.SetActive(!Pause.activeInHierarchy);
                else Pause.SetActive(!Pause.activeInHierarchy);
            }


            yield return null;
        }
    }
}
