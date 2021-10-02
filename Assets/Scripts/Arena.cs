using UnityEngine;

public class Arena : MonoBehaviour {
    [SerializeField] private float secondsToShrink = 60f;
    [SerializeField][Range(0.05f, 1f)] private float shrinkToPercent = .2f;
    
    private float shrinkScale;
    private float shrinkThreshold;

    private void Start() {
        var localScale = transform.localScale;
        shrinkThreshold = localScale.x * shrinkToPercent;
        shrinkScale = (localScale.x - shrinkThreshold) / secondsToShrink;
    }

    void Update() {
        var localScale = transform.localScale;
        if (localScale.x > shrinkThreshold) {
            localScale.x = Mathf.Clamp(localScale.x - shrinkScale * Time.deltaTime, shrinkThreshold, float.MaxValue);
        }

        if (localScale.z > shrinkThreshold) {
            localScale.z = Mathf.Clamp(localScale.z - shrinkScale * Time.deltaTime, shrinkThreshold, float.MaxValue);
        }
        transform.localScale = localScale;
    }
}
