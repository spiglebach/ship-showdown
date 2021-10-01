using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private bool wasdPlayer;

    public bool WasdPlayer => wasdPlayer;
}
