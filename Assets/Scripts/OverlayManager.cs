using TMPro;
using UnityEngine;

public class OverlayManager : MonoBehaviour {
    [SerializeField] private TMP_Text wasdPlayerScoreText;
    [SerializeField] private TMP_Text arrowPlayerScoreText;
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
