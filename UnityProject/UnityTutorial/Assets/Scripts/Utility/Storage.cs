using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour {

    public int coin_num_;

    private void Start() {
        DontDestroyOnLoad(gameObject);
    }

}
