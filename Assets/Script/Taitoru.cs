using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Taitoru : MonoBehaviour {
    Animator animator;
    private bool isTButtonClick = false;
    [SerializeField] private GameObject TButton;
    [SerializeField] private GameObject TPanel;
    [SerializeField] private GameObject T2Panel;
    [SerializeField] private GameObject Text1;
    [SerializeField] private GameObject Text2;
    GameObject panel;
    // Use this for initialization
    void Start () {
        panel = GameObject.Find("Panel");
        animator = GetComponent<Animator>();
        Invoke("Win",3f);
        Invoke("Button", 5f);
    }
	
	// Update is called once per frame
	void Update () {
        Invoke("Keri", 1);
        Invoke("Text", 4);
        //Invoke("Ban",3);
        if (panel.transform.position.y >= 332) {
            TPanel.SetActive(false);
            T2Panel.SetActive(true);
        }

            if (this.isTButtonClick) {
            this.isTButtonClick = false;
            SceneManager.LoadScene("GameScene");
        }
    }
    void Win() {
        animator.SetTrigger("Win");
    }
     public void GetMyTaitBottonClick() {
        this.isTButtonClick = true; 
    }
    void Button() {
        TButton.SetActive(true);
        Text1.SetActive(true);
    }
    void Text() {
        Text2.SetActive(true);

    }
    void Keri() {
        if (panel.transform.position.y <= 332) {
            panel.transform.Rotate(new Vector3(0, 30, 0));
            panel.transform.localScale += new Vector3(0.013f, 0.013f, 0.01f);
            panel.transform.position += new Vector3(2.7f, 2.7f, 0);
        }
        
    }
    void Ban() {
        TPanel.SetActive(false);
        T2Panel.SetActive(true);
        //GameObject.Find("WinBGM").GetComponent<AudioSource>().Play();
    }
}
