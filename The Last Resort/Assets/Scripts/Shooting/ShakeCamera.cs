using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    GameObject cameraToShake;

    public float shakingDuration = 1f;
    public float shakingMagnitude = 0.4f;

    Vector3 preferPosition = new Vector3(0f, 0.8f, 0.28f);

    private void Start()
    {
        StartCoroutine(Shake(shakingDuration, shakingMagnitude));
    }
    private void Awake()
    {
        cameraToShake = GameObject.FindGameObjectWithTag("MainCamera");
    }
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = cameraToShake.transform.localPosition;
        if(originalPosition != preferPosition)
        {
            originalPosition = preferPosition;
        }

        float elapsed = 0.0f;
        while(elapsed < duration)
        {
            float positionX = Random.Range(-1f, 1f) * magnitude;
            float positionY = Random.Range(-1f, 1f) * magnitude;

            cameraToShake.transform.localPosition = new Vector3(positionX, positionY, originalPosition.z);

            elapsed += Time.deltaTime;
            magnitude -= Time.deltaTime/2;

            yield return null;
        }

        cameraToShake.transform.localPosition = originalPosition;
    }
}
