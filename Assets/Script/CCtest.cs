using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCtest : MonoBehaviour {
    public float speed = 3.0f;
    float moveX = 0f;
    float moveZ = 0f;
    private CharacterController controller;
    private Animator animator;
    private bool isRButtonDown = false;
    Touch touch;
    // Use this for initialization
    void Start(){
            controller = GetComponent<CharacterController>();
        this.animator = GetComponent<Animator>();
    }
 
        void Update() {
        Debug.Log(isRButtonDown);
        //Touch myTouch = Input.GetTouch(0);

        Touch[] myTouches = Input.touches;
        for(int i = 0; i < Input.touchCount; i++)
        {
            float x = touch.deltaPosition.x;
            float y = touch.deltaPosition.y;
            Vector2 direction = new Vector2(x, y);
            if (Input.touches[i].phase == TouchPhase.Began) {
                //touch.position
            }
        }
        

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || this.isRButtonDown || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.LeftArrow)) {
                this.transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
            }
            if (Input.GetKey(KeyCode.RightArrow) || this.isRButtonDown) {
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
    public void GetMyRightButtonDown() {
        this.isRButtonDown = true;
    }
    //右ボタンを離した場合
    public void GetNyRightButtonUp() {
        this.isRButtonDown = false;
    }
}
