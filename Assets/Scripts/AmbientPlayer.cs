using UnityEngine;

public class AmbientPlayer : MonoBehaviour {
    private void Awake() {
        if (FindObjectsOfType<AmbientPlayer>().Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }
}
