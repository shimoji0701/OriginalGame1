using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public GameObject OpenButton1;
    public GameObject OpenButton2;
    public GameObject OpenButton3;
    bool empty1 = true;
    bool empty2 = true;

    Status status;
    Animator Ianimator;
    private bool isOpenButtonClick = false;
    // Use this for initialization
    void Start () {
        status = GameObject.Find("BattleHero").GetComponent<Status>();
        Ianimator = GameObject.Find("Item1").GetComponent<Animator>();
    }	
	// Update is called once per frame
	void Update () {
       
    }
     void OnTriggerStay(Collider other)
    {
        if (other.tag == "Item1" && empty1 == true) {
            OpenButton1.SetActive(true);
            if (isOpenButtonClick) {
                status.Weapon = 1.2f;
                OpenButton1.SetActive(false);
                this.isOpenButtonClick = false;
                empty1 = false;
            }                  
        }
        if (other.tag == "Item2" && empty2 == true) {
            OpenButton2.SetActive(true);
            if (isOpenButtonClick) {
                status.Armor = 0.9f;
                OpenButton2.SetActive(false);
                this.isOpenButtonClick = false;
                empty2 = false;
            }                  
        }            
    }

     void OnTriggerExit(Collider other)
    {
        if (other.tag == "Item1"|| other.tag == "Item2") {
        OpenButton1.SetActive(false);
            OpenButton2.SetActive(false);
        }
        //if (other.tag == "Item2") {
        
        //}
    }
    public void GetMyOpenBottonClick() {
        this.isOpenButtonClick = true;
        Debug.Log(12345);
    }
}

