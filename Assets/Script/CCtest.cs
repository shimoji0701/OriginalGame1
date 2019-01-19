using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCtest : MonoBehaviour {
    public float speed = 3.0f;
    float moveX = 0f;
    float moveZ = 0f;
    private CharacterController controller;
    private Animator animator;

    // Use this for initialization
    void Start(){
            controller = GetComponent<CharacterController>();
        this.animator = GetComponent<Animator>();
    }
 
        void Update() {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.LeftArrow)) {
                this.transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
            }
            if (Input.GetKey(KeyCode.RightArrow)) {
                this.transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
            }
            if (Input.GetKey(KeyCode.UpArrow)) {
                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }
            if (Input.GetKey(KeyCode.DownArrow)) {
                this.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            }
            moveX = Input.GetAxis ("Horizontal") * speed;
            moveZ = Input.GetAxis ("Vertical") * speed;
            Vector3 direction = new Vector3(moveX , 0, moveZ);
            this.animator.SetBool("WalkBool", true);

            controller.SimpleMove(direction);
        }
        //矢印キーを離したとき
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            this.animator.SetBool("WalkBool", false);
        }
    }
}
