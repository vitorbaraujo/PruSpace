using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float targetRatio = 9f/16f; //The aspect ratio you did for the game.
	void Start()
	{
		Camera cam = GetComponent<Camera>();
		cam.aspect = targetRatio;
		cam.orthographic = true;
		cam.ResetAspect();
	}

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
