using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [SerializeField] private bool wasdPlayer;
    [SerializeField] private int health = 100;
    [SerializeField] private int ramDamage = 45;
    [SerializeField] private float ramCooldown = 3f;

    [SerializeField] private Text healthText; // TODO use TextMeshPro

    public bool WasdPlayer => wasdPlayer;
    
    private float remainingRamCooldown;

    private void Start() {
        DisplayHealth();
    }

    private void Update() {
        remainingRamCooldown -= Time.deltaTime;
    }

    public void TakeDamage(int amount) {
        health -= amount;
        if (health <= 0) {
            PlayerDestroyed();
            
        }
        DisplayHealth();
    }

    private void PlayerDestroyed() {
        gameObject.SetActive(false);
        // TODO play VFX and SFX
        ScoreSystem.Instance.PlayerDestroyed(this);
    }

    private void OnCollisionEnter(Collision other) {
        if (remainingRamCooldown > 0 || !other.gameObject.TryGetComponent(out Player otherPlayer)) return;
        otherPlayer.TakeDamage(ramDamage);
        remainingRamCooldown = ramCooldown;
    }

    private void DisplayHealth() {
        healthText.text = health <= 0 ? "X_X" : health.ToString();
    }
}
