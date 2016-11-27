using UnityEngine;
using System.Collections;

public class CoinGenerator : MonoBehaviour {

    [SerializeField]
    private GameObject coin_prefab_;

    //public GameObject coin_prefab_; でもよいが、上を推奨

    private void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            Instantiate(coin_prefab_, RandomCoinPos(), Quaternion.identity);
        }
    }

    //コインの生成位置をランダムに返す
    private Vector3 RandomCoinPos() {
        int pos_x = Random.Range(-90, 90);
        int pos_z = Random.Range(-90, 90);

        Vector3 pos = new Vector3(pos_x, 5, pos_z);
        return pos;
    }

}
