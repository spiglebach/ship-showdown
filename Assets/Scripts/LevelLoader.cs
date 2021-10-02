using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    public void NextRound() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu() {
        SceneManager.LoadScene(0);
    }

    public void Play() {
        SceneManager.LoadScene(1);
    }

    public void Quit() {
        Application.Quit();
    }
}
