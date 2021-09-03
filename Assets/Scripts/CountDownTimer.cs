using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public int countdownTime; 
    public Text countdownDisplay;
    private void Start()
    {
        StartCoroutine(CountdownToGameOver());
    }
    IEnumerator CountdownToGameOver()
    {
        while(countdownTime > 0)
        {
            countdownDisplay.text = "Time:" + countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }
        countdownDisplay.text = "Game Over";
    }
}
