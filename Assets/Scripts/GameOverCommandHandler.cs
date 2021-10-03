using UnityEngine;

public class GameOverCommandHandler : MonoBehaviour {

    void Update() {
        if (Input.GetKeyDown(KeyCode.N)) {
            FindObjectOfType<LevelLoader>().NextRound();
        }
        if (Input.GetKeyDown(KeyCode.M)) {
            FindObjectOfType<LevelLoader>().MainMenu();
        }
    }
}
