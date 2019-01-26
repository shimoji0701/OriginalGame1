using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour {

    private GameObject unityChan;
    private float differenceX;
    private float differenceY;
    private float differenceZ;
    // Use this for initialization
    void Start()
    {
        this.unityChan = GameObject.Find("unitychan");
        this.differenceX = unityChan.transform.position.x - this.transform.position.x;
        this.differenceY = unityChan.transform.position.y - this.transform.position.y;
        this.differenceZ = unityChan.transform.position.z - this.transform.position.z;

       // Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position = new Vector3(this.unityChan.transform.position.x - differenceX, this.unityChan.transform.position.y - differenceY, this.unityChan.transform.position.z - differenceZ);
    }
}
