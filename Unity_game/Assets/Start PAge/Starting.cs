using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starting : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private string scene="game scene" ;
    public void StartGame() {
        SceneManager.LoadScene(scene);
    }
}
