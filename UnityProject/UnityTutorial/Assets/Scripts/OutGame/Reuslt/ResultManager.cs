using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour {

    [SerializeField]
    private Text result_;

    private void Start() {
        int coin_num_ = GameObject.Find("Storage").GetComponent<Storage>().coin_num_;

        result_.text = "Score " + coin_num_;
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("Title");
        }
    }
}
