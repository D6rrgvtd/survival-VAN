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
        if (attackCooldown < 0.1f) attackCooldown = 0.1f;
        Debug.Log("攻撃速度アップ！ 現在の攻撃間隔: " + attackCooldown + "秒");
    }

   
    public void AddNewWeapon()
    {
        
        AutoAttack newWeapon = gameObject.AddComponent<AutoAttack>();

       
        newWeapon.bulletPrefab = this.bulletPrefab;
        newWeapon.attackCooldown = this.attackCooldown;

        Debug.Log("★新しい武器が追加されました！");
    }
}
