using UnityEngine;

public class Cannonball : MonoBehaviour {
    [SerializeField] private int damageAmount = 20;
    [SerializeField] private float lifetimeInSeconds = 2f;

    private Player ownerPlayer;

    private void Start() {
        Destroy(gameObject, lifetimeInSeconds);
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.TryGetComponent(out Player collidedPlayer) || collidedPlayer == ownerPlayer) return;
        collidedPlayer.TakeDamage(damageAmount);
        Destroy(gameObject);
    }

    public void SetOwnerPlayer(Player player) {
        ownerPlayer = player;
    }
}
