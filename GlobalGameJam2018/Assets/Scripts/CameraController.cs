using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public static CameraController instance = null;

	public bool isShaking = false;

	IEnumerator ShakeInTime(float shakeIntensity, float shakeTotalTime, float shakeDelay)
    {
        isShaking = true;
        
        float shakeTimer = 0f;

        while (shakeTimer <= shakeTotalTime)
        {

            transform.position = transform.position + Random.insideUnitSphere * shakeIntensity;
            yield return new WaitForSeconds(shakeDelay);
            shakeTimer += shakeDelay;
        }
        isShaking = false;
    }

	public void ShakeCameraInTime(float shakeIntensity, float shakeTotalTime, float shakeDelay)
    {
        StartCoroutine(ShakeInTime(shakeIntensity, shakeTotalTime, shakeDelay));
    }
}
