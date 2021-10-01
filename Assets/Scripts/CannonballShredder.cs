using UnityEngine;

public class CannonballShredder : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Cannonball")) {
            Destroy(other.gameObject);
        }
    }
}
