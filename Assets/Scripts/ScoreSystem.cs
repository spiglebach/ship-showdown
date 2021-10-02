using UnityEngine;

public class ScoreSystem : MonoBehaviour {
    public static ScoreSystem Instance;

    private int wasdPlayerScore = 0;
    private int arrowPlayerScore = 0;

    public int WasdPlayerScore => wasdPlayerScore;
    public int ArrowPlayerScore => arrowPlayerScore;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayerDestroyed(Player destroyedPlayer) {
        if (destroyedPlayer.WasdPlayer) {
            arrowPlayerScore++;
        } else {
            wasdPlayerScore++;
        }
        FindObjectOfType<OverlayManager>().GameOver(this);
    }
}
