using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHand : MonoBehaviour
{
    public GameObject[] gamePieces;
    public GameObject[] playerHand;

    public GameObject[] pieceCoaster;

    public Text scoreText;


    void Start()
    {
    //get game all game pieces and player piece objects
        gamePieces = GameObject.FindGameObjectsWithTag("Dragabble");
        pieceCoaster = GameObject.FindGameObjectsWithTag("PieceCoaster");
        playerHand = GameObject.FindGameObjectsWithTag("PlayerHand");




    //loop through each player piece object and position a random gamepice over it
        for (var i = 0; i < pieceCoaster.Length; i++)
        if(pieceCoaster[i].tag == "PieceCoaster")
        {
                gamePieces[Random.Range(0, gamePieces.Length)].transform.position = pieceCoaster[i].transform.position;
                
                pieceCoaster[i].transform.tag = "PlayerHand";

            //only transform a pleyerhand if there isn't a gamepiece there already

            //how do we know if its there already?
            
        // Debug.Log(playerHand);
            
        }
    }
}
