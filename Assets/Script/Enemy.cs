using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private Animator animator;
    public int EHP = 80;
	// Use this for initialization
	void Start () {
        this.animator = GetComponent<Animator>();
	}	
	// Update is called once per frame
	void Update () {
        
    }
    public void EnemyAttack() {
        if (EHP > 0) { 
        animator.SetBool("Attack", true);
        Invoke("Call1",1f);
        Invoke("Call2", 2f);
        Invoke("Call3", 2.5f);
        Debug.Log("敵が攻撃");
            //Debug.Log(EHP);
        }
        else if(EHP <= 0) {
            Destroy(gameObject);
            Debug.Log("敵を倒した");
        }
    }
    void Call1() {
        animator.SetBool("Attack", false);
        GetComponent<AudioSource>().PlayDelayed(0.3f);
    }
    void Call2() {
        animator.SetBool("Back", true);
    }
    void Call3() {
        animator.SetBool("Back", false);
    }
}
