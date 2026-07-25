using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    public int currentExp = 0; // 現在の経験値
    public int nextLevelExp = 5; // レベルアップに必要な経験値
    public int currentLevel = 1; // 現在のレベル
    private AutoAttack autoAttack; // ★攻撃の台本を覚える用

    void Start()
    {
        // ★自分（Player）にくっついているAutoAttackスクリプトを取得する
        autoAttack = GetComponent<AutoAttack>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Exp"))
        {
            currentExp++;
            Destroy(collision.gameObject);

            if (currentExp >= nextLevelExp)
            {
                LevelUp();
            }
        }
    }

    void LevelUp()
    {
        currentLevel++;
        currentExp = 0;
        nextLevelExp += 5;
        Debug.Log("レベルアップ！現在のレベル: " + currentLevel);

        // ★【追加】レベルが上がるごとに、攻撃間隔を0.15秒ずつ短くして強くする！
        if (autoAttack != null)
        {
            autoAttack.IncreaseAttackSpeed(0.15f);
        }
    }
}
