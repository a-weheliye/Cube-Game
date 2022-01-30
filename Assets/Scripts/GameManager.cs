

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public bool gameEnded = false;
    public bool noLives = false;
    public float restartDelay = 1f;

    public GameObject completeLevelUI;
    // public Transform player;
    // private static int _numLives = 3;

    public void CompletedLevel() {
        print("Level WON");
        completeLevelUI.SetActive(true);
    }
    
    public void EndGame() {
        if (!gameEnded) {
            gameEnded = true;
            ScoreScript.NumLives -= 1;
            // print("Game Over!");
            Debug.Log("Lives = "+ScoreScript.NumLives);
            if (ScoreScript.NumLives > 0) {
                Invoke("Restart", restartDelay);
            }
            else {
                Invoke("GameOver", 2);
            }
        }
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ScoreScript.ScoreValue -= 5;
    }

    void GameOver() {
        SceneManager.LoadScene("Scenes/Credits");
    }

}
