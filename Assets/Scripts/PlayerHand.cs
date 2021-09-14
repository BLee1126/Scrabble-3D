using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHand : MonoBehaviour
{
    public GameObject[] gamePieces;
    public GameObject[] playerHand;

    public Text scoreText;


    void Start()
    {
        //get all game pieces and player piece objects
        gamePieces = GameObject.FindGameObjectsWithTag("Dragabble");
        playerHand = GameObject.FindGameObjectsWithTag("PlayerHand");

        // Bool check to see if a collider gameObject is at position
        bool isObjectHere(Vector3 position)
        {
            Collider[] intersecting = Physics.OverlapSphere(position, 0.01f);
            return (intersecting.Length != 0);
        }
        //loop through each player piece object and position a random gamepiece over it
        for (int i = 0; i < playerHand.Length; i++)
        {
            if(!isObjectHere(playerHand[i].transform.position))
            {
                var randomInt = Random.Range(0, gamePieces.Length);
                gamePieces[randomInt].transform.position = playerHand[i].transform.position;
            }
        }


    }
}
