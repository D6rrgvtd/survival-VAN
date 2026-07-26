using UnityEngine;
using TMPro; 

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; 
    private float elapsedTime; 
    private bool isGameOver = false;

    void Update()
    {
       
        if (!isGameOver)
        {
            elapsedTime += Time.deltaTime;

         
            int minutes = Mathf.FloorToInt(elapsedTime / 60F);
            int seconds = Mathf.FloorToInt(elapsedTime % 60F);

            
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

   
    public void StopTimer()
    {
        isGameOver = true;
    }
}
