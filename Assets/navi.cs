using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navi : MonoBehaviour {
    public Transform target;
    NavMeshAgent agent;
    private Animator animator;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        this.animator = GetComponent<Animator>();


    }
	
	// Update is called once per frame
	void Update () {
        NavMeshPath path = agent.path; //経路パス（曲がり角座標のVector3配列）を取得
        float dist = 0f;
        Vector3 corner = transform.position; //自分の現在位置
                                             //曲がり角間の距離を累積していく
        for (int i = 0; i < path.corners.Length; i++)
        {
            Vector3 corner2 = path.corners[i];
            dist += Vector3.Distance(corner, corner2);
            corner = corner2;
           // Debug.Log(dist);
        }
            Debug.Log(dist);

        if (dist <=3) {
            agent.SetDestination(target.position);
            agent.speed = 5;
        }
        else {
            agent.speed = 2;
}
    }
}
