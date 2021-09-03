using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUtility : MonoBehaviour
{
    public GameObject[] GamePieces;
    public int xPos;
    public int zPos;
    // Start is called before the first frame update
    void Start()
    {
        if (GamePieces != null){
            GamePieces = GameObject.FindGameObjectsWithTag("Shuffle");
        }
        
        foreach (GameObject piece in GamePieces)
        {
            xPos = Random.Range(200,300);
            zPos = Random.Range(-150,200);
            piece.transform.position = new Vector3(xPos, 0, zPos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
