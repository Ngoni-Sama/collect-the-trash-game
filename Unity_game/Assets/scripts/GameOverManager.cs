using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour
{
    public GameObject player;       // Reference to the player's health.
    public float restartDelay = 5f;         // Time to wait before restarting the level
    public GameObject scoreBoard;
    private bool GameOver=false;
    Animator anim;                          // Reference to the animator component.
    float restartTimer;                     // Timer to count up to restarting the level


    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        scoreBoard = GameObject.FindGameObjectWithTag("score");
    }


    void Update()
    {
        // If the player has run out of health...
        if ((player.GetComponent<player_controller>().pollution <= 0 || player.GetComponent<player_controller>().pollution>=100 || player.GetComponent<player_controller>().timeLeft <= 0) && !GameOver)
        {
            scoreBoard.GetComponent<Text>().text="Score: " + (int)((10000000)/((player.GetComponent<player_controller>().pollution+1)*(player.GetComponent<player_controller>().timeLeft+1)));
            // ... tell the animator the game is over.
            anim.SetTrigger("gameover");
            GameOver = true;
            
        }
        else if ((player.GetComponent<player_controller>().pollution <= 0 || player.GetComponent<player_controller>().pollution >= 100 || player.GetComponent<player_controller>().timeLeft <= 0))
        {
            // .. increment a timer to count up to restarting.
            restartTimer += Time.deltaTime;

            // .. if it reaches the restart delay...
            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene("startscene");
                // .. then reload the currently loaded level.
                // SceneManager.LoadScene(Application.loadedLevel);
            }
        }
    }
}