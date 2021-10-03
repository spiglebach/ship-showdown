using System;
using UnityEngine;

public class MainMenuInputHandler : MonoBehaviour {
    [SerializeField] private GameObject controlsOverlay;

    private void Start() {
        CloseControls();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            FindObjectOfType<LevelLoader>().Play();
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            ShowControls();
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            FindObjectOfType<LevelLoader>().Quit();
        }
        if (Input.GetKeyDown(KeyCode.B)) {
            CloseControls();
        }
    }

    public void ShowControls() {
        controlsOverlay.SetActive(true);
    }

    public void CloseControls() {
        controlsOverlay.SetActive(false);
    }
}
