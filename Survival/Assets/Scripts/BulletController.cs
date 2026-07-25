using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject expOrbPrefab; 

    void Start()
    {
        Destroy(gameObject, 2.0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            
            if (expOrbPrefab != null)
            {
                Instantiate(expOrbPrefab, collision.transform.position, Quaternion.identity);
            }

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
