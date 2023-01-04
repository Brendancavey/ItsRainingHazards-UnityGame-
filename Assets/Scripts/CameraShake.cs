using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public float duration = 1f;
    public AnimationCurve curve;
    public void Shake()
    {
        StartCoroutine(Shaking());
    }
    IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float shakeStrength = curve.Evaluate(elapsedTime/duration);
            transform.position = startPosition + Random.insideUnitSphere * shakeStrength;
            yield return null;
        }
        transform.position = startPosition;
    }
}
