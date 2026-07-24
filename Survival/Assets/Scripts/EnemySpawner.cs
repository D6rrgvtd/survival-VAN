using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public float spawnInterval = 2.0f; 
    public float spawnRadius = 12.0f; 
    private Transform playerTransform;
    private float timer;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null) playerTransform = player.transform;
    }

    void Update()
    {
        if (playerTransform == null) return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    void SpawnEnemy()
    {
        
        float angle = Random.Range(0f, Mathf.PI * 2);
        Vector3 spawnOffset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * spawnRadius;
        Vector3 spawnPosition = playerTransform.position + spawnOffset;

        
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
