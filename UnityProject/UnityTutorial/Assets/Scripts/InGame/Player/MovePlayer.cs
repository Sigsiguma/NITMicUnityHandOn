using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

    private const float move_speed_ = 0.2f;

    private void Update() {

        if (Input.GetKey(KeyCode.LeftArrow)) {
            Vector3 pos = transform.position;
            pos.x -= move_speed_;
            transform.position = pos;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            Vector3 pos = transform.position;
            pos.x += move_speed_;
            transform.position = pos;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            Vector3 pos = transform.position;
            pos.z -= move_speed_;
            transform.position = pos;
        } else if (Input.GetKey(KeyCode.UpArrow)) {
            Vector3 pos = transform.position;
            pos.z += move_speed_;
            transform.position = pos;
        }
    }
}