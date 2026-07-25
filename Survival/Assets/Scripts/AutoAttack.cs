using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public float attackCooldown = 1.0f; 
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= attackCooldown)
        {
            
            GameObject enemy = GameObject.FindWithTag("Enemy");

            if (enemy != null)
            {
                
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                Vector3 direction = (enemy.transform.position - transform.position).normalized;
                bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * 10f;

                timer = 0;
            }
        }
    }

    public void IncreaseAttackSpeed(float amount)
    {
        attackCooldown -= amount;
        // UŒ‚ŠÔŠu‚ª0•bˆÈ‰º‚É‚È‚Á‚ÄƒQ[ƒ€‚ªƒtƒŠ[ƒY‚·‚é‚Ì‚ğ–h‚®iÅ’á0.1•bj
        if (attackCooldown < 0.1f)
        {
            attackCooldown = 0.1f;
        }
        Debug.Log("UŒ‚‘¬“xƒAƒbƒvI Œ»İ‚ÌUŒ‚ŠÔŠu: " + attackCooldown + "•b");
    }
}
