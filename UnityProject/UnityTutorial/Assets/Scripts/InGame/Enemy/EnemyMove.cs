using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour {

    [SerializeField]
    private Transform player_;

    private NavMeshAgent agent_;

    //最新の目的地を保持
    private Vector3 pos_;

    private void Awake() {
        agent_ = GetComponent<NavMeshAgent>();
    }

    private void Start() {
        Patrol();
    }

    private void Update() {

        if (player_ == null) return;

        float player_distance = Vector3.Distance(player_.position, transform.position);
        float target_distance = Vector3.Distance(transform.position, pos_);

        if (player_distance < 50f) {
            pos_ = player_.position;
            agent_.SetDestination(player_.position);
        } else if (target_distance < 10f) {
            Patrol();
        }

    }

    private void Patrol() {

        float x = Random.Range(-100f, 100f);
        float z = Random.Range(-100f, 100f);

        pos_ = new Vector3(x, 0, z);

        agent_.SetDestination(pos_);
    }

}
