using UnityEngine;

public class MainMenuInputHandler : MonoBehaviour {
    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            FindObjectOfType<LevelLoader>().Play();
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            FindObjectOfType<LevelLoader>().Quit();
        }
    }
}
