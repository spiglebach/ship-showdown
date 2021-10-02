using UnityEngine;

public class PlayerActions : MonoBehaviour {
    [SerializeField] private Transform perpendicularLeft;
    [SerializeField] private Transform perpendicularRight;
    [SerializeField] private Transform leftCannons;
    [SerializeField] private Transform rightCannons;
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
        var cannonballForceTargetVector = enemyOnRightHandSide ? perpendicularRight.position : perpendicularLeft.position;
        var cannons = enemyOnRightHandSide ? rightCannons : leftCannons;

        foreach (Transform cannon in cannons) {
            var cannonball = Instantiate(cannonballPrefab, cannon.position, Quaternion.identity);
            cannonball.GetComponent<Rigidbody>().AddForce((cannonballForceTargetVector - transform.position) * cannonForceScale, ForceMode.VelocityChange);
            cannonball.GetComponent<Cannonball>().SetOwnerPlayer(player);
        }
    }
}
