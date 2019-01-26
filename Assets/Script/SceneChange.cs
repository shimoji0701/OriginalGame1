using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour {
    [SerializeField] private GameObject Stage2Button;
    private bool isStage2ButtonClick = false;
    bool fadeout = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (fadeout == true) {
            GameObject.Find("FadeCanvas").GetComponent<FadeImage>().Range += 0.05f;
            
        }
    }
    private void OnTriggerStay(Collider other) {
       if(other.tag == "Stege2") {
            GetComponent<CharacterController>(). enabled = false;
            Stage2Button.SetActive(true);
            Invoke("Stage2", 3);
            Invoke("Fadeout", 1); 

        }
        if (other.tag == "Stage3") {
            GetComponent<CharacterController>().enabled = false;
            Stage2Button.SetActive(true);
            Invoke("Stage3", 3);
            Invoke("Fadeout", 1);
            
            
        }
        if (other.tag == "BOSS") {
            GetComponent<CharacterController>().enabled = false;
            Stage2Button.SetActive(true);
            Invoke("BOSS", 3);
            Invoke("Fadeout", 1);
            
            
        } 
    }
     public void GetMyStage2BottonClick() {
        this.isStage2ButtonClick = true; 
    }
   
    void Stage2() {
        SceneManager.LoadScene("Stage2");
        Stage2Button.SetActive(false);
    }
    void Stage3() {
        SceneManager.LoadScene("Stage3");
        Stage2Button.SetActive(false);
    }
    void BOSS() {
        SceneManager.LoadScene("Boss");
        Stage2Button.SetActive(false);
    }
    void Fadeout() {
        fadeout = true;
            GameObject.Find("BGM").GetComponent<AudioSource>().Stop();
        GameObject.Find("SceneChange").GetComponent<AudioSource>().PlayDelayed(0.2f);
    }
}
