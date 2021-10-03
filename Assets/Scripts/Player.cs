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

    private void Start() {
        remainingHealth = maxHealth;
        healthText = healthSlider.gameObject.GetComponentInChildren<TMP_Text>();
        DisplayHealth();
    }

    private void Update() {
        remainingRamCooldown -= Time.deltaTime;
    }

    public void TakeDamage(int amount) {
        remainingHealth -= amount;
        if (remainingHealth <= 0) {
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
        healthText.text = remainingHealth <= 0 ? "X_X" : remainingHealth.ToString();
        healthSlider.value = remainingHealth * 1f / maxHealth;
    }
}
