using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayGame : MonoBehaviour
{
    public Text scoreText;
    public GameObject[] PlayedPieces;
    public int TurnScore;
    public static int StartScore = 0;
    public GameObject[] gamePieces;
    public GameObject[] playerHand;
    
    public bool isWord = false;

    public GameObject[] tripleLetter;
    public GameObject[] tripleWord;
    public bool isTripleWord = false;

    public GameObject wordDef;
    public GameObject wordPlayed;

    public List<GameObject> PlayedPiecePos = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        // int score = MainMenu.score;
        // scoreText.text = "Score: " + score.ToString();
        // scoreText.text = "TESTING";
        StartScore = 0;
    }

    // Update is called once per frame
    public void SubmitTurn()
    {
        string[,] SetPieces = new string[16,16];
        PlayedPieces = GameObject.FindGameObjectsWithTag("Snapped");
        foreach (GameObject piece in PlayedPieces)
        {
            int x = -1;
            int y = -1;
            // Debug.Log(piece.GetComponent<Text>().text.Substring(0,1));
            // Debug.Log(piece.GetComponent<Text>().text.Substring(1,1));
            //setting x pos for letter in array
            if((int)Mathf.Ceil(piece.transform.position.x) == -144){
                x = 0;
            }
            else if((int)Mathf.Ceil(piece.transform.position.x) == -124){
                x = 1;
            }
            else if((int)Mathf.Ceil(piece.transform.position.x) == -104){
                x = 2;
            }
            else if((int)Mathf.Ceil(piece.transform.position.x) == -84){
                x=3;
            }
            else if((int)Mathf.Ceil(piece.transform.position.x) == -64){
                x=4;
            }
            else if((int)Mathf.Ceil(piece.transform.position.x) == -44){
                x=5;
            }
            else if((int)Mathf.Ceil(piece.transform.position.x) == -24){
                x=6;
            }
            else if((int)Mathf.Ceil(piece.transform.position.x) == -4){
                x=7;
            }
            else if((int)Mathf.Floor(piece.transform.position.x) == 16){
                x=8;
            }
            else if((int)Mathf.Floor(piece.transform.position.x) == 36){
                x=9;
            }
            else if((int)Mathf.Floor(piece.transform.position.x) == 56){
                x=10;
            }
            else if((int)Mathf.Floor(piece.transform.position.x) == 76){
                x=11;
            }
            else if((int)Mathf.Floor(piece.transform.position.x) == 96){
                x=12;
            }
            else if((int)Mathf.Floor(piece.transform.position.x) == 116){
                x=13;
            }
            else if((int)Mathf.Floor(piece.transform.position.x) == 136){
                x=14;
            }

            //setting y pos for array
            if((int)Mathf.Floor(piece.transform.position.z) == 138){
                y=0;
            }
            else if((int)Mathf.Floor(piece.transform.position.z) == -118){
                y=1;
            }
            else if((int)Mathf.Floor(piece.transform.position.z) == 98){
                y=2;
            }
            else if((int)Mathf.Floor(piece.transform.position.z) == 78){
                y=3;
            }
            else if((int)Mathf.Floor(piece.transform.position.z) == 58){
                y=4;
            }
            else if((int)Mathf.Floor(piece.transform.position.z) == 38){
                y=5;
            }
            else if((int)Mathf.Floor(piece.transform.position.z) == 18){
                y=6;
            }
            else if((int)Mathf.Ceil(piece.transform.position.z) == -2){
                y=7;
            }
            else if((int)Mathf.Ceil(piece.transform.position.z) == -22){
                y=8;
            }
            else if((int)Mathf.Ceil(piece.transform.position.z) == -42){
                y=9;
            }
            else if((int)Mathf.Ceil(piece.transform.position.z) == -62){
                y=10;
            }
            else if((int)Mathf.Ceil(piece.transform.position.z) == -82){
                y=11;
            }
            else if((int)Mathf.Ceil(piece.transform.position.z) == -102){
                y=12;
            }
            else if((int)Mathf.Ceil(piece.transform.position.z) == -122){
                y=13;
            }
            else if((int)Mathf.Ceil(piece.transform.position.z) == -142){
                y=14;
            }
            if(x != -1 && y!= -1){
                SetPieces[x,y] = piece.GetComponent<Text>().text.Substring(0,1);
                // PlayedPiecePos.Add(piece);
            }

            // check for triple word score
            tripleWord = GameObject.FindGameObjectsWithTag("TripleWord");
            foreach(var tw in tripleWord)
            {
                if(piece.transform.position == tw.transform.position)
                {
                    Debug.Log("triple word score");
                    Debug.Log(tw);
                    isTripleWord = true;
                }
            }

            // check for triple letter score
            tripleLetter = GameObject.FindGameObjectsWithTag("TripleLetter");
            foreach(var tl in tripleLetter)
            {
                if(piece.transform.position == tl.transform.position)
                {
                    Debug.Log("triple letter score");
                    Debug.Log(tl);
                    var pieceValue = int.Parse(piece.GetComponent<Text>().text.Substring(1,1));
                    TurnScore += pieceValue * 2;
                } 
            }

            TurnScore += int.Parse(piece.GetComponent<Text>().text.Substring(1,1));
        }

        List<string> AllWords= new List<string>();
        // Debug.Log(TurnScore);
        string tempWord = "";
        for (int j = 0; j<15; j++)
        {
            for(int k = 0; k<15; k++)
            {
                if(SetPieces[k,j] != null && !SetPieces[k,j].Equals(null))
                {
                    while(SetPieces[k,j] != null && !SetPieces[k,j].Equals(null) && k<15)
                    {
                        tempWord += SetPieces[k,j];
                        k++;
                    }
                    if (tempWord.Length > 1)
                    {
                        AllWords.Add(tempWord);
                    }
                    tempWord="";
                }
            }
        }
        for (int k = 0; k<15; k++)
        {
            for(int j = 0; j<15; j++)
            {
                if(SetPieces[k,j] != null && !SetPieces[k,j].Equals(null))
                {
                    while(SetPieces[k,j] != null && !SetPieces[k,j].Equals(null) && j<15)
                    {
                        tempWord += SetPieces[k,j];
                        j++;
                    }
                    if (tempWord.Length > 1)
                    {
                        AllWords.Add(tempWord);
                    }
                    tempWord="";
                }
            }
        }
        foreach(string word in AllWords){
            Debug.Log(word);
            Validate(word);
        }
        // Validate(tempWord);


        

        // StartScore += TurnScore;
        // gameObject.GetComponent<Score>().AddScore((int) TurnScore);
        // var FindObjectOfType<Score>();
        // Score.GetComponent<Score> ().AddScore(TurnScore);
        
        }


    public void AddScore(int score) {
        // int CurrentScore = StartScore + score;
        StartScore += score;
        // scoreText.text = "Score: " + CurrentScore.ToString();
        Debug.Log(score);
        // scoreText.text = $"SCORE: {score}";

    }

    public void UpdateScore()
    {
        scoreText.text = $"SCORE: {StartScore}";
    }

    public dynamic Validate(string Word2)
    {
        // A correct website page.
        StartCoroutine(GetRequest($"https://api.dictionaryapi.dev/api/v2/entries/en/{Word2}"));

        // A non-existing page.
        // StartCoroutine(GetRequest("https://error.html"));
        return "hi";
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            if (webRequest.isDone)
            {
                string[] pages = uri.Split('/');
                int page = pages.Length - 1;

                switch (webRequest.result)
                {
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.DataProcessingError:
                        Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                        isWord = false;
                        yield return false;
                        break;
                    case UnityWebRequest.Result.ProtocolError:
                        Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                        isWord = false;
                        yield return false;
                        break;
                    case UnityWebRequest.Result.Success:
                        //display shortened definition 
                        int beginningIndex = webRequest.downloadHandler.text.IndexOf("\"definition\"");
                        string shortenedDef = webRequest.downloadHandler.text.Substring(beginningIndex, 160);
                        var foundIndexes = new List<int>();
                        for (int i = 0; i < shortenedDef.Length; i++)
                        {
                            if (shortenedDef[i] == '"')
                            {
                                foundIndexes.Add(i);
                            }
                        }
                        string finalDef = webRequest.downloadHandler.text.Substring(beginningIndex, foundIndexes[4] -1);
                        wordPlayed.GetComponent<Text>().text = pages[page];
                        wordDef.GetComponent<Text>().text = finalDef;

                        isWord = true;
                        yield return true;
                        break;
                }
            }
            yield return false;
        }
        if(isWord){

            int played = 0;
            foreach(GameObject piece in PlayedPieces){
                played++;
                // GameObject.Destroy(piece);
            }

            // if triple word is true turnscore * 3
            if(isTripleWord)
            {
                AddScore(TurnScore * 3);
            } else 
            {
                AddScore(TurnScore);
            }

            // Debug.Log(PlayedPiecePos.Count);
            // AddScore(TurnScore);
            // scoreText.text = $"SCORE: {TurnScore}";
            scoreText.GetComponent<Text>().text = "SCORE:" + StartScore;
            TurnScore = 0;

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
            isWord = false;
        }
    }
}
