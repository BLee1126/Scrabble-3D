using UnityEngine;
using UnityEngine.Networking;
using System.Collections;



// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class APIManager : MonoBehaviour
{
    string Word {get;set;}
    public string Definition {get;set;}
    public void Validate(string Word2)
    {
        // A correct website page.
        StartCoroutine(GetRequest($"https://api.dictionaryapi.dev/api/v2/entries/en/{Word2}"));

        // A non-existing page.
        // StartCoroutine(GetRequest("https://error.html"));
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
                        yield return false;
                        break;
                    case UnityWebRequest.Result.ProtocolError:
                        Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                        yield return false;
                        break;
                    case UnityWebRequest.Result.Success:
                        Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                        yield return true;
                        break;
                }
            }
        }
    }
}
