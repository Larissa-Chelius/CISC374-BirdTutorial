using UnityEngine;
using System.Collections;

public class ScreenShakeScript : MonoBehaviour
{
    public float shakeDuration = 0.3f;  // Duration of the shake
    public float shakeMagnitude = 0.2f; // Strength of the shake
    private Vector3 originalPosition;

    void Awake()
    {
        originalPosition = transform.position; // Make sure position is reset correctly
    }

    void OnEnable()
    {
        originalPosition = transform.position; // Ensure it resets on scene reload
    }

    public void TriggerShake()
    {
        StopAllCoroutines();  // Prevents interference with previous shakes
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float xOffset = Random.Range(-1f, 1f) * shakeMagnitude;
            float yOffset = Random.Range(-1f, 1f) * shakeMagnitude;
            
            transform.position = new Vector3(originalPosition.x + xOffset, originalPosition.y + yOffset, originalPosition.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition; // Reset position
    }
}
