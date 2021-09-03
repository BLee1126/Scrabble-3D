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

    public GameObject wordDef;
    public GameObject wordPlayed;
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
        string[,] SetPieces = new string[15,15];
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
            else if((int)Mathf.Floor(piece.transform.position.z) == -102){
                y=12;
            }
            else if((int)Mathf.Floor(piece.transform.position.z) == -122){
                y=13;
            }
            else if((int)Mathf.Floor(piece.transform.position.z) == -142){
                y=14;
            }
            if(x != -1 && y!= -1){
                SetPieces[x,y] = piece.GetComponent<Text>().text.Substring(0,1);
            }
            TurnScore += int.Parse(piece.GetComponent<Text>().text.Substring(1,1));
        }

        List<string> AllWords= new List<string>();
        Debug.Log(TurnScore);
        string tempWord = "";
        for (int k = 0; k<15; k++)
        {
            for(int j = 0; j<15; j++)
            {
                if(SetPieces[k,j] != null && !SetPieces[k,j].Equals(null))
                {
                    while(SetPieces[k,j] != null && !SetPieces[k,j].Equals(null))
                    {
                        // Debug.Log(k);
                        tempWord += SetPieces[k,j];
                        j++;
                    }
                }
                // if(SetPieces[k,j] == null){
                    // AllWords.Add(tempWord);
                // }
            }
        }
        AllWords.Add(tempWord);
        foreach(string word in AllWords){
            Debug.Log(word);
        }
        Validate(tempWord);


        

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
                        // Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                        // Debug.Log(System.Type.GetType(webRequest.downloadHandler.text));
                        int beginningIndex = webRequest.downloadHandler.text.IndexOf("\"definition\"");
                        // int beginningIndex = webRequest.downloadHandler.text.IndexOf("\"example\"");
                        Debug.Log(webRequest.downloadHandler.text.Length);
                        string shortened = webRequest.downloadHandler.text.Substring(beginningIndex, 125);
                        // Debug.Log(shortened.GetType());
                        wordPlayed.GetComponent<Text>().text = pages[page];
                        wordDef.GetComponent<Text>().text = shortened;
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
                GameObject.Destroy(piece);
            }
            AddScore(TurnScore);
            // scoreText.text = $"SCORE: {TurnScore}";
            scoreText.GetComponent<Text>().text = "SCORE:" + StartScore;
            TurnScore = 0;

            gamePieces = GameObject.FindGameObjectsWithTag("Dragabble");
            playerHand = GameObject.FindGameObjectsWithTag("PlayerHand");

            //loop through each player piece object and position a random gamepice over it
            for (var i = 0; i < played; i++)
            if(gamePieces[i] != null)
            {
            gamePieces[Random.Range(0, gamePieces.Length)].transform.position = playerHand[i].transform.position;
            
            }
            isWord = false;
        }
    }
}
