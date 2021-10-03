using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    public void NextRound() {
        if (ScoreSystem.Instance) ScoreSystem.Instance.ClearGameOver();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu() {
        if (ScoreSystem.Instance) ScoreSystem.Instance.ClearScore();
        SceneManager.LoadScene(0);
    }

    public void Play() {
        if (ScoreSystem.Instance) ScoreSystem.Instance.ClearScore();
        SceneManager.LoadScene(1);
    }

    public void Quit() {
        if (ScoreSystem.Instance) ScoreSystem.Instance.ClearScore();
        Application.Quit();
    }
}
