using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Restart : MonoBehaviour {

    public void OnClick() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

}
