using UnityEngine;

public class Arena : MonoBehaviour {
    [SerializeField] private float secondsToShrink = 60f;
    [SerializeField] private float shrinkThreshold = 10;
    
    [SerializeField] private GameObject leftWall;
    [SerializeField] private GameObject rightWall;
    [SerializeField] private GameObject topWall;
    [SerializeField] private GameObject bottomWall;
    
    private float shrinkAmount;

    private void Start() {
        var rightWallPosition = rightWall.transform.position;
        shrinkAmount = (rightWallPosition.x - shrinkThreshold) / secondsToShrink;
    }

    void Update() {
        if (leftWall.transform.position.x < -shrinkThreshold)
            leftWall.transform.Translate(shrinkAmount * Time.deltaTime, 0, 0, Space.World);
        if (rightWall.transform.position.x > shrinkThreshold)
            rightWall.transform.Translate(-shrinkAmount * Time.deltaTime, 0, 0, Space.World);
        if (topWall.transform.position.z > shrinkThreshold)
            topWall.transform.Translate(0, 0, -shrinkAmount * Time.deltaTime, Space.World);
        if (bottomWall.transform.position.z < -shrinkThreshold)
            bottomWall.transform.Translate(0, 0, shrinkAmount * Time.deltaTime, Space.World);
    }
}
