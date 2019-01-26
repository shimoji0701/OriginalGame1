using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2 : MonoBehaviour {
    public GameObject OpenButton1;
    public GameObject OpenButton2;
    public GameObject OpenButton3;

    public GameObject Message;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4;
    bool empty1 = true;
    bool empty2 = true;
    bool empty3 = true;
    Status2 status;
    Animator Ianimator;
    private bool isOpenButtonClick = false;
    private bool isNextButtonClick = false;
    public static bool MPItem = false;
    // Use this for initialization
    void Start() {
        status = GameObject.Find("BattleHero").GetComponent<Status2>();
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
                Status2.Weapon = 1.4f;
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
                Status2.Armor = 0.5f;
                OpenButton2.SetActive(false);
                this.isOpenButtonClick = false;
                empty2 = false;
            }
        }
        if (other.tag == "Item3" && empty3 == true) {
            OpenButton3.SetActive(true);
            if (isOpenButtonClick) {
                Message.SetActive(true);
                Text4.SetActive(true);
                Invoke("TextUnder", 1.5f);
                Invoke("Close", 5);
                Status2.MP += 10;
                MPItem = true;
                OpenButton3.SetActive(false);
                this.isOpenButtonClick = false;
                empty3 = false;
            }
        }
    }


    

     void OnTriggerExit(Collider other)
    {
        if (other.tag == "Item1"|| other.tag == "Item2" || other.tag == "Item3") {
        OpenButton1.SetActive(false);
            OpenButton2.SetActive(false);
            OpenButton3.SetActive(false);
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
        Text4.SetActive(false);
    }
    public void GetMyOpenBottonClick() {
        this.isOpenButtonClick = true;
        GameObject.Find("Item1").GetComponent<AudioSource>().Play();
    }
    public void GetMyNextBottonClick() {
        this.isNextButtonClick = true;
    }
    public static bool getI(){
		return MPItem;
	}
}
