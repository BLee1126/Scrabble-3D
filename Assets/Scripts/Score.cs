using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
  public Text scoreText;
  public int StartScore = 0;

  private void Start() {
    int score = MainMenu.score;
    scoreText.text = "Score: " + score.ToString();
  }

  public void AddScore(int score) {
    scoreText.text = "Score: " + (StartScore + score).ToString();
  }
}