using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

    private const float move_speed_ = 10.0f;

    private Rigidbody rgbd_;

    private void Awake() {
        rgbd_ = GetComponent<Rigidbody>();
    }

    private void Update() {

        if (Input.GetKey(KeyCode.LeftArrow)) {
            Vector3 vel = rgbd_.velocity;
            vel.x = -move_speed_;
            rgbd_.velocity = vel;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            Vector3 vel = rgbd_.velocity;
            vel.x = move_speed_;
            rgbd_.velocity = vel;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            Vector3 vel = rgbd_.velocity;
            vel.z = -move_speed_;
            rgbd_.velocity = vel;
        } else if (Input.GetKey(KeyCode.UpArrow)) {
            Vector3 vel = rgbd_.velocity;
            vel.z = move_speed_;
            rgbd_.velocity = vel;
        } else {
            rgbd_.velocity = Vector3.zero;
        }
    }
}