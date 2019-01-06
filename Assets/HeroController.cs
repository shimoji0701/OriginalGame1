using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        this.rigidbody = GetComponent<Rigidbody>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //矢印キーを押したとき
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
            this.transform.position += new Vector3(Input.GetAxis("Horizontal") * 0.1f, 0, Input.GetAxis("Vertical") * 0.1f);
            this.animator.SetBool("WalkBool", true);
           
        }
        //矢印キーを離したとき
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            this.animator.SetBool("WalkBool", false);
        }

    }
}
