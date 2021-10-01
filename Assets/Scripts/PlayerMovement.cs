using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float forceScale = 100f;
    [SerializeField] private float rotationScale = 50f;

    private Player player;

    private Rigidbody playerRigidbody;

    private readonly KeyCode[] WasdMovementControls = {KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D};
    private readonly KeyCode[] ArrowMovementControls = {KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow};

    private Vector3 movementDirection = Vector3.zero;

    void Start() {
        playerRigidbody = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
    }

    void Update() {
        ProcessMovementInput();
    }

    private void AlignRotation() {
        if (movementDirection == Vector3.zero) return;
        var direction = Quaternion.LookRotation(movementDirection);
        playerRigidbody.rotation = Quaternion.RotateTowards(transform.rotation, direction, rotationScale);
    }

    private void FixedUpdate() {
        AlignRotation();
    }

    private void ProcessMovementInput() {
        movementDirection = player.WasdPlayer ? GetWasdPlayerMovementVector() : GetArrowPlayerMovementVector();
        if (movementDirection == Vector3.zero) return;
        playerRigidbody.AddRelativeForce(Vector3.forward * (forceScale * Time.deltaTime), ForceMode.VelocityChange);
    }

    private Vector3 GetWasdPlayerMovementVector() {
        return WasdMovementControls.Aggregate(Vector3.zero, (current, keyCode) => current + GetForceVectorForKey(keyCode));
    }

    private Vector3 GetArrowPlayerMovementVector() {
        return ArrowMovementControls.Aggregate(Vector3.zero, (current, keyCode) => current + GetForceVectorForKey(keyCode));
    }

    private Vector3 GetForceVectorForKey(KeyCode keyCode) {
        if (!Input.GetKey(keyCode)) return Vector3.zero;
        switch (keyCode) {
            case KeyCode.W:
            case KeyCode.UpArrow:
                return Vector3.forward;
            case KeyCode.A:
            case KeyCode.LeftArrow:
                return Vector3.left;
            case KeyCode.S:
            case KeyCode.DownArrow:
                return Vector3.back;
            case KeyCode.D:
            case KeyCode.RightArrow:
                return Vector3.right;
            default:
                return Vector3.zero;
        }
    }
}
