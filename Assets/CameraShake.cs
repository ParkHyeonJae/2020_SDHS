using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{   
    private float force;
    private float duration;
    private Camera mainCam;

    public static System.Action<float, float> OnShake;

    public void Awake()
    {
        OnShake = CamShake;
    }

    public void CamShake(float force = 5.0f, float duration = 1.0f)
        => StartCoroutine(Shake(force, duration));

    public IEnumerator Shake(float force, float duration)
    {
        this.force = force;
        this.duration = duration;

        mainCam = Camera.main;
        Vector3 startPos = mainCam.transform.position;
        float curTime = 0f;
        while (curTime <= duration)
        {
            curTime += Time.deltaTime;
            mainCam.transform.position = startPos + Random.insideUnitSphere * force;
            yield return null;
        }
        mainCam.transform.position = startPos;
        yield return null;
    }
}
