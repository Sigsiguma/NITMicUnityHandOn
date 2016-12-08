using UnityEngine;
using System.Collections;

public class CoinGenerator : MonoBehaviour {

    private const float generate_span_ = 2f;

    [SerializeField]
    private GameObject coin_prefab_;

    private void Start() {
        StartCoroutine(GenerateCoin());
    }

    private IEnumerator GenerateCoin() {

        while (true) {
            Instantiate(coin_prefab_, RandomCoinPos(), Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }

    //コインの生成位置をランダムに返す
    private Vector3 RandomCoinPos() {
        int pos_x = Random.Range(-90, 90);
        int pos_z = Random.Range(-90, 90);

        Vector3 pos = new Vector3(pos_x, 1, pos_z);
        return pos;
    }

}
