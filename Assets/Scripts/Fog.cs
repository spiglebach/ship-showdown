using UnityEngine;

public class Fog : MonoBehaviour {
    [SerializeField] private float damageFrequency = 1f;
    [SerializeField] private int periodicDamageAmount = 5;

    private float timeLeftToDealDamage;

    private void OnTriggerStay(Collider other) {
        if (timeLeftToDealDamage > 0) return; 
        if (!other.gameObject.TryGetComponent(out Player player)) return;
        Debug.Log($"Trigger stay: {other.gameObject.name}");
        player.TakeDamage(periodicDamageAmount);
    }

    void FixedUpdate() {
        if (timeLeftToDealDamage <= 0) timeLeftToDealDamage += damageFrequency;
        timeLeftToDealDamage -= Time.deltaTime;
    }
}
