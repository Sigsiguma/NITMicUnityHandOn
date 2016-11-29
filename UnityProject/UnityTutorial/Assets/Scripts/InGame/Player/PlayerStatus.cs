using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

    private int coin_num_;

    private void Awake() {
        coin_num_ = 0;
    }

    private void OnTriggerEnter(Collider other) {

        //もし、衝突対象がコインなら
        if (other.tag == "coin") {
            ++coin_num_;
        }

    }
}
