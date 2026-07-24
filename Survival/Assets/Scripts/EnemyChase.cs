using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float speed = 3;
    private Transform playerTransform;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void FixedUpdate()
    {
        if (playerTransform != null)
        {
           
            Vector2 direction = (playerTransform.position - transform.position).normalized;
           
            rb.linearVelocity = direction * speed;
        }
    }
}
