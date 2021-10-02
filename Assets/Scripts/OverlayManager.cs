using UnityEngine;
using UnityEngine.UI;

public class OverlayManager : MonoBehaviour {
    [SerializeField] private Text wasdPlayerScoreText; // TODO use TextMeshPro
    [SerializeField] private Text arrowPlayerScoreText; // TODO use TextMeshPro
    [SerializeField] private GameObject roundOverCanvas;
    
    void Start() {
        roundOverCanvas.SetActive(false);
        DisplayScore(FindObjectOfType<ScoreSystem>());
    }

    private void DisplayScore(ScoreSystem scoreSystem) {
        wasdPlayerScoreText.text = scoreSystem.WasdPlayerScore.ToString();
        arrowPlayerScoreText.text = scoreSystem.ArrowPlayerScore.ToString();
    }

    public void GameOver(ScoreSystem scoreSystem) {
        DisplayScore(scoreSystem);
        roundOverCanvas.SetActive(true);
    }
}
