using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private bool wasdPlayer;
    [SerializeField] private int health = 100;

    public bool WasdPlayer => wasdPlayer;

    public void TakeDamage(int amount) {
        health -= amount;
        if (health <= 0) {
            PlayerDestroyed();
        }
    }

    private void PlayerDestroyed() {
        gameObject.SetActive(false);
    }
}
