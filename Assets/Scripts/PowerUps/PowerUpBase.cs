using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : MonoBehaviour
{
    [SerializeField] float _powerUpDuration;

    Collider _obj_collider;
    MeshRenderer _mesh;

    [SerializeField]
    ParticleSystem _collectedParticles;

    [SerializeField]
    AudioClip __collectedAudioClip;

    Player player;

    private void Awake()
    {
        _obj_collider = GetComponent<Collider>();
        _mesh = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<Player>();
        if (player == null)
            return;

        DisablePowerUp();
        PowerUp(player);
        UpdatePlayer(player);
        Feedback();
    }

    void Feedback()
    {
        if (_collectedParticles != null)
        {
            Instantiate(_collectedParticles, transform.position, Quaternion.identity);
            _collectedParticles = Instantiate(_collectedParticles,
                transform.position, Quaternion.identity);
            _collectedParticles.Play();
        }

        if (__collectedAudioClip != null)
        {
            AudioHelper.PlayClip2D(__collectedAudioClip, 1f);
        }
    }

    protected virtual void PowerUp(Player playerCharacter) => StartCoroutine(powerUpTimer());
    protected virtual void PowerDown(Player playerCharacter) 
    {
        UpdatePlayer(playerCharacter);
        gameObject.SetActive(false); 
    }

    protected virtual void UpdatePlayer(Player playerCharacter) => player = playerCharacter;

    void DisablePowerUp()
    {
        _obj_collider.enabled = false;
        _mesh.enabled = false;
    }

    IEnumerator powerUpTimer()
    {
        float currentTimer = 0f;

        while(currentTimer <= _powerUpDuration)
        {
            currentTimer += Time.deltaTime;
            yield return null;
        }

        PowerDown(player);
    }
}
