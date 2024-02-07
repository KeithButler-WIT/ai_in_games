using UnityEngine;

public class Move : MonoBehaviour {

    public GameObject goal;
    Vector3 direction;
    float speed = 0.05f;

    void Start() {
        direction = goal.transform.position - this.transform.position;
        // this.transform.position = this.transform.position + direction;
        // this.transform.Translate(goal.transform.position);
    }

    private void LateUpdate() {
        Vector3 velocity = direction.normalized * speed;
        this.transform.position = this.transform.position + velocity;
    }
}
