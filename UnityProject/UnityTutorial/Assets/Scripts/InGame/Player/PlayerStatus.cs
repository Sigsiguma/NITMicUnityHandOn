using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

    private int coin_num_;

    private void Awake() {
        coin_num_ = 0;
    }

    private void OnTriggerEnter(Collider other) {

        //もし、衝突対象がコインなら
        if (other.tag == "Coin") {
            ++coin_num_;
            Debug.Log(coin_num_);
        }

    }

    private void OnCollisionEnter(Collision other) {

        if (other.transform.tag == "Enemy") {
            //ゲームオーバー
            Destroy(gameObject);
        }

    }
}
