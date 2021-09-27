using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] float _shakeDuration;
    [SerializeField] float _shakeMagnitude;

    [SerializeField] CharacterHealth player;

    Vector3 _originalPos;
    void Awake() => _originalPos = transform.localPosition;

    private void OnEnable() => player.HitEvent += Coroutine_CameraShake;

    private void OnDisable() => player.HitEvent -= Coroutine_CameraShake;

    void Coroutine_CameraShake(float currentHealth, float maxHealth) => 
        StartCoroutine(CameraShake(_shakeDuration, _shakeMagnitude));

    IEnumerator CameraShake(float duration, float magnitude)
    {
        float elapsedTime = 0f;
        while(elapsedTime < duration)
        {
            float xOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            float yOffset = Random.Range(-0.5f, 0.5f) * magnitude;

            transform.localPosition = new Vector3(xOffset, yOffset, _originalPos.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = _originalPos;
    }
}