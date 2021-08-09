using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{

    private Vector3 _originalPos;
    public static CameraShake _instance;
    public static bool shakeNow = false;

    private void Update()
    {
        if (shakeNow)
        {
            _instance.StopAllCoroutines();
            _instance.StartCoroutine(_instance.cShake(0.1f,0.08f));
            shakeNow = false;
        }
    }

    void Awake()
    {
        _originalPos = transform.localPosition;

        _instance = this;
    }

    public static void Shake(float duration, float amount)
    {
        _instance.StopAllCoroutines();
        _instance.StartCoroutine(_instance.cShake(duration, amount));
    }

    public IEnumerator cShake(float duration, float amount)
    {
        Debug.Log("here");
        float endTime = Time.time + duration;

        while (Time.time < endTime)
        {
            transform.localPosition = _originalPos + Random.insideUnitSphere * amount;

            duration -= Time.deltaTime;

            yield return null;
        }

        transform.localPosition = _originalPos;
    }
}