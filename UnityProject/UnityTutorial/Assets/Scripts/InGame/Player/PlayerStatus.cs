using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour {

    private int coin_num_;

    [SerializeField]
    private Text score_text_;

    private void Awake() {
        coin_num_ = 0;
    }

    private void OnTriggerEnter(Collider other) {

        //もし、衝突対象がコインなら
        if (other.tag == "Coin") {
            ++coin_num_;
            score_text_.text = "Score " + coin_num_;
        }

    }

    private void OnCollisionEnter(Collision other) {

        if (other.transform.tag == "Enemy") {

            GameObject.Find("Storage").GetComponent<Storage>().coin_num_ = coin_num_;

            //ゲームオーバー
            Destroy(gameObject);

            SceneManager.LoadScene("Result");
        }

    }
}
