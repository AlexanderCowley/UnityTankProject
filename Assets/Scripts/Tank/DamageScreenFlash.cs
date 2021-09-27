using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class DamageScreenFlash : MonoBehaviour
{
    CharacterHealth _health;
    Image _flashImage;
    void Awake()
    {
        _health = GetComponentInParent<CharacterHealth>();
        _flashImage = GetComponentInChildren<Image>();
    }

    private void OnEnable()
    {
        _health.HitEvent += ScreenFlash;
    }

    private void OnDisable()
    {
        _health.HitEvent -= ScreenFlash;
    }
    void ScreenFlash(float currentHealth, float maxHealth)
    {
        StartCoroutine(ColorFlash(.1f, .25f));
    }

    IEnumerator ColorFlash(float duration, float flashRate)
    {   
        Color tempColor = new Color(255, 0, 0, .6f * flashRate);
        _flashImage.color = tempColor;
            

        yield return new WaitForSeconds(duration);

        Color finalColor = new Color(255, 0, 0, 0f);
        _flashImage.color = finalColor;
    }
}