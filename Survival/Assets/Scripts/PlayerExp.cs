using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    public int currentExp = 0;
    public int nextLevelExp = 5;
    public int currentLevel = 1;
    private AutoAttack autoAttack;

    void Start()
    {
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

        if (autoAttack != null)
        {
            // ★【条件変更】もし上がったレベルが「5の倍数（5, 10, 15...）」なら新しい武器を追加
            if (currentLevel % 5 == 0)
            {
                autoAttack.AddNewWeapon();
            }
            else
            {
                // ★5の倍数以外のレベルでは、通常通り連射速度をアップさせる
                autoAttack.IncreaseAttackSpeed(0.15f);
            }
        }
    }
}
