using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [SerializeField] private bool wasdPlayer;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int ramDamage = 45;
    [SerializeField] private float ramCooldown = 3f;

    [SerializeField] private Slider healthSlider;

    public bool WasdPlayer => wasdPlayer;
    
    private float remainingRamCooldown;
    private int remainingHealth;
    private TMP_Text healthText;
    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        remainingHealth = maxHealth;
        healthText = healthSlider.gameObject.GetComponentInChildren<TMP_Text>();
        DisplayHealth();
    }

    private void Update() {
        remainingRamCooldown -= Time.deltaTime;
    }

    public void TakeDamage(int amount) {
        if (ScoreSystem.Instance.IsGameOver) return;
        remainingHealth -= amount;
        if (remainingHealth <= 0) {
            PlayerDestroyed();
        }
        DisplayHealth();
    }

    private void PlayerDestroyed() {
        GetComponentInChildren<Renderer>().enabled = false;
        if (audioSource) audioSource.Play();
        ScoreSystem.Instance.PlayerDestroyed(this);
    }

    private void OnCollisionEnter(Collision other) {
        if (remainingRamCooldown > 0 || !other.gameObject.TryGetComponent(out Player otherPlayer)) return;
        otherPlayer.TakeDamage(ramDamage);
        if (audioSource) audioSource.Play();
        remainingRamCooldown = ramCooldown;
    }

    private void DisplayHealth() {
        healthText.text = remainingHealth <= 0 ? "X_X" : $"{remainingHealth.ToString()}/{maxHealth.ToString()}";
        healthSlider.value = remainingHealth * 1f / maxHealth;
    }
}
