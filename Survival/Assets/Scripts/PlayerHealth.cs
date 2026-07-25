using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHp = 3; // 最大HP（3回耐えられる）
    private int currentHp;

    void Start()
    {
        currentHp = maxHp; // ゲーム開始時にHPをいっぱいに
    }

    // 敵の体にぶつかった瞬間に呼び出される関数
    void OnCollisionEnter2D(Collision2D collision)
    {
        // ぶつかった相手のタグが「Enemy」なら
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHp--; // HPを1減らす
            Debug.Log("ダメージ！ 残りHP: " + currentHp);

            // 敵も同時に消す（プレイヤーに突撃して自爆するイメージ）
            Destroy(collision.gameObject);


            if (currentHp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}