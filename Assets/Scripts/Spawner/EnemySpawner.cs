using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy _enemyPrefab;
    Text _messageText;
    void Awake()
    {
        _messageText = GetComponentInChildren<Text>();
    }

    void Spawn()
    {
        _enemyPrefab = Instantiate
            (_enemyPrefab, transform.position, Quaternion.identity);
        _messageText.text = string.Format("{0} spawned ", _enemyPrefab.name);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }
    }
}