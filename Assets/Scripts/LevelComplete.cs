

using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelComplete : MonoBehaviour
{
    public AudioSource levelComplete;

    private void Start() {
        levelComplete.Play();
    }

    public void LoadnextLevel() {
        // levelComplete.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
