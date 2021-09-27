using UnityEngine.UI;
using UnityEngine;

public class DisplayHealth : MonoBehaviour
{
    Image fg_healthBar;
    CharacterHealth char_health;
    void Awake()
    {
        char_health = transform.root.GetComponent<CharacterHealth>();
        fg_healthBar = transform.GetChild(1).GetComponent<Image>();
    }

    private void OnEnable() => char_health.HitEvent += UpdateHealthBar;


    private void OnDisable() => char_health.HitEvent += UpdateHealthBar;

    void UpdateHealthBar(float new_health, float maxHealth)
    {
        fg_healthBar.fillAmount = Mathf.Clamp(new_health/maxHealth, 0, 1f);
    }
}