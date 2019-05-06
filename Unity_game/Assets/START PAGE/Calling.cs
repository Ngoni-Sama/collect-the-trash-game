using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Calling : MonoBehaviour {

    // Use this for initialization
    public void quit() {
        Application.Quit();
    }
    public void start_game() {
        SceneManager.LoadScene("game scene");
    }
    public void menu()
    {
        SceneManager.LoadScene("startscene");
    }
    public void help()
    {
        SceneManager.LoadScene("helpScene");
    }
}
