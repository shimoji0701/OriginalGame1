using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public GameObject OpenButton1;
    public GameObject OpenButton2;
    public GameObject OpenButton3;

    public GameObject Message;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    bool empty1 = true;
    bool empty2 = true;

    Status status;
    Animator Ianimator;
    private bool isOpenButtonClick = false;
    private bool isNextButtonClick = false;
    // Use this for initialization
    void Start() {
        status = GameObject.Find("BattleHero").GetComponent<Status>();
        Ianimator = GameObject.Find("Item1").GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update() {
        
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Item1" && empty1 == true) {
            OpenButton1.SetActive(true);
            if (isOpenButtonClick) {
                Message.SetActive(true);
                Text1.SetActive(true);
                Invoke("TextUnder", 1.5f);
                Invoke("Close", 5);
                Status.Weapon = 1.2f;
                OpenButton1.SetActive(false);
                this.isOpenButtonClick = false;
                empty1 = false;
            }
        }
        if (other.tag == "Item2" && empty2 == true) {
            OpenButton2.SetActive(true);
            if (isOpenButtonClick) {
                Message.SetActive(true);
                Text3.SetActive(true);
                Invoke("TextUnder", 1.5f);
                Invoke("Close", 5);
                Status.Armor = 0.75f;
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
    }
    void TextUnder() {
        Text2.SetActive(true);
    }
    void Close() {
        Message.SetActive(false);
        Text2.SetActive(false);
        Text1.SetActive(false);
        Text3.SetActive(false);
    }
    public void GetMyOpenBottonClick() {
        this.isOpenButtonClick = true;
        GameObject.Find("Item1").GetComponent<AudioSource>().Play();
    }
    public void GetMyNextBottonClick() {
        this.isNextButtonClick = true;
    }
}

