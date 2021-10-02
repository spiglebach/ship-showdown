using UnityEngine;

public class PlayerActions : MonoBehaviour {
    [SerializeField] private Transform leftCannonSpawner;
    [SerializeField] private Transform rightCannonSpawner;
    [SerializeField] private GameObject cannonballPrefab;

    [SerializeField] private float cannonForceScale;

    private Player player;

    private void Start() {
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (player.WasdPlayer) {
            ProcessWasdPlayerInput();
        } else {
            ProcessArrowPlayerInput();
        }
        
    }

    private void ProcessArrowPlayerInput() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            Fire();
        }
    }

    private void ProcessWasdPlayerInput() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Fire();
        }
    }

    private void Fire() {
        var leftCannonballSpawnerPosition = leftCannonSpawner.position;
        var rightCannonballSpawnerPosition = rightCannonSpawner.position;
        var leftCannonball = Instantiate(cannonballPrefab, leftCannonballSpawnerPosition, Quaternion.identity);
        var rightCannonball = Instantiate(cannonballPrefab, rightCannonballSpawnerPosition, Quaternion.identity);
        leftCannonball.GetComponent<Rigidbody>().AddForce((leftCannonballSpawnerPosition - transform.position) * cannonForceScale, ForceMode.VelocityChange);
        rightCannonball.GetComponent<Rigidbody>().AddForce((rightCannonballSpawnerPosition - transform.position) * cannonForceScale, ForceMode.VelocityChange);
        leftCannonball.GetComponent<Cannonball>().SetOwnerPlayer(player);
        rightCannonball.GetComponent<Cannonball>().SetOwnerPlayer(player);
    }
}
