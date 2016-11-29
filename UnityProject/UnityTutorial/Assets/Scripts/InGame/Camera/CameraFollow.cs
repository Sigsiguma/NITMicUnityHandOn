﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private Transform target_;

    [SerializeField]
    private Vector3 difference_;

    private void LateUpdate() {
        transform.position = target_.position + difference_;
    }
}

