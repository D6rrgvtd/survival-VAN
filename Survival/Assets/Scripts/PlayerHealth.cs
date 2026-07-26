using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHp = 3;
    private int currentHp;

  
    public GameObject gameOverText;

    void Start()
    {
        currentHp = maxHp;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHp--;
            Debug.Log("ダメージ！ 残りHP: " + currentHp);

            Destroy(collision.gameObject);

            if (currentHp <= 0)
            {
                Debug.Log("ゲームオーバー！");

                
                if (gameOverText != null)
                {
                    gameOverText.SetActive(true);
                }

                GameTimer timer = FindFirstObjectByType<GameTimer>();

              
                if (timer != null)
                {
                    timer.StopTimer();
                }


                gameObject.SetActive(false);
            }
        }
    }
}
