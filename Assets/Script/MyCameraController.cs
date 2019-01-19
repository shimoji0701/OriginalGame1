using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour {

    private GameObject unityChan;
    private float differenceX;
    private float differenceZ;
    // Use this for initialization
    void Start()
    {
        this.unityChan = GameObject.Find("unitychan");
        this.differenceX = unityChan.transform.position.x - this.transform.position.x;
        this.differenceZ = unityChan.transform.position.z - this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.unityChan.transform.position.x - differenceX, this.transform.position.y, this.unityChan.transform.position.z - differenceZ);
    }
}
