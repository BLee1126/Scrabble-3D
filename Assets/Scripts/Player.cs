using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
  public Text playerText;

  private void Start() {
    if(MainMenu.playerName != null)
    {
      string player = MainMenu.playerName;
      playerText.text = player;
    }
  }
}