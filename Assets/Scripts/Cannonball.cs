using UnityEngine;

public class Cannonball : MonoBehaviour {
    [SerializeField] private int damageAmount = 20;
    [SerializeField] private float lifetimeInSeconds = .5f;
    [SerializeField] private float lifetimeNoiseInSeconds = .05f;
    [SerializeField][Range(0.5f, 1f)] private float minVolume = 0.8f;
    [SerializeField][Range(0.5f, 1f)] private float minPitch = 0.5f;
    [SerializeField][Range(1f, 1.5f)] private float maxPitch = 1.2f;
    [SerializeField] private AudioClip impactClip;
    [SerializeField] private AudioClip splashClip;

    private Player ownerPlayer;
    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = Random.Range(minVolume, 1f);
        audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.Play();
        Invoke(nameof(SplashIntoWater), Random.Range(lifetimeInSeconds - lifetimeNoiseInSeconds, lifetimeInSeconds + lifetimeNoiseInSeconds));
    }

    private void SplashIntoWater() {
        audioSource.volume = Random.Range(.4f, .6f);
        audioSource.pitch = Random.Range(.2f, .6f);
        audioSource.PlayOneShot(splashClip);
        InactivateAndDestroy();
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.TryGetComponent(out Player collidedPlayer) || collidedPlayer == ownerPlayer) return;
        collidedPlayer.TakeDamage(damageAmount);
        audioSource.volume = Random.Range(.4f, .6f);
        audioSource.pitch = Random.Range(.2f, .6f);
        audioSource.PlayOneShot(impactClip);
        InactivateAndDestroy();
    }

    public void SetOwnerPlayer(Player player) {
        ownerPlayer = player;
    }

    private void InactivateAndDestroy() {
        GetComponentInChildren<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject, 2f);
    }
}
