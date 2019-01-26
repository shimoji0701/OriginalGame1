using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ivent : MonoBehaviour {
    [SerializeField] private GameObject MessageUI;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay(Collider col) {
        //敵(Enemyタグ)に衝突したとき
		if(col.tag == "Ivent1") {
            MessageUI.SetActive(true);
            GetComponent<CharacterController>(). enabled = false;
            Destroy(col.gameObject);
        }
        }
}
