using UnityEngine;

public class PlayerActions : MonoBehaviour {
    [SerializeField] private Transform leftCannonSpawner;
    [SerializeField] private Transform rightCannonSpawner;
    [SerializeField] private GameObject cannonballPrefab;

    [SerializeField] private float cannonForceScale;

    private Player player;
    private Player enemyPlayer;

    private void Start() {
        player = GetComponent<Player>();
        foreach (var otherPlayer in FindObjectsOfType<Player>()) {
            if (otherPlayer == player) continue;
            enemyPlayer = otherPlayer;
            break;
        }
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
        var shipForward = Quaternion.AngleAxis(transform.rotation.eulerAngles.y, Vector3.up) * Vector3.forward;
        var vectorToEnemy = (enemyPlayer.transform.position - transform.position).normalized;
        var crossProduct = Vector3.Cross(shipForward, vectorToEnemy);
        if (crossProduct.y == 0) return;
        
        var enemyOnRightHandSide = crossProduct.y > 0;
        var cannonballSpawnerPosition = enemyOnRightHandSide ? rightCannonSpawner.position : leftCannonSpawner.position;
        
        var cannonball = Instantiate(cannonballPrefab, cannonballSpawnerPosition, Quaternion.identity);
        cannonball.GetComponent<Rigidbody>().AddForce((cannonballSpawnerPosition - transform.position) * cannonForceScale, ForceMode.VelocityChange);
        cannonball.GetComponent<Cannonball>().SetOwnerPlayer(player);
    }
}
