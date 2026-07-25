using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float baseSpawnInterval = 2.0f; 
    public float spawnRadius = 12.0f;
    private Transform playerTransform;
    private PlayerExp playerExp; 
    private float timer;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            playerTransform = player.transform;
            
            playerExp = player.GetComponent<PlayerExp>();
        }
    }

    void Update()
    {
        if (playerTransform == null || playerExp == null) return;

        timer += Time.deltaTime;

       
        float currentInterval = baseSpawnInterval / playerExp.currentLevel;
        if (currentInterval < 0.2f) currentInterval = 0.2f;

        if (timer >= currentInterval)
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
