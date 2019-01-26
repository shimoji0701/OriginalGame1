using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Battle : MonoBehaviour {
    [SerializeField] private GameObject CommandPanel;
    [SerializeField] private GameObject SkilPanel;
    [SerializeField] private GameObject FlamePanel;
    [SerializeField] private GameObject TitleButton;
    private bool isAButtonClick = false;
    private bool isSButtonClick = false;
    private bool isBackButtonClick = false;
    private bool isSkilButtonClick = false;
    private bool isSkil2ButtonClick = false;
    private bool isSkilButtonEnter = false;
    private bool isTitleButtonClick = false;

    private AudioSource sound01;
    private AudioSource sound02;
    private AudioSource sound03;

    public Status status;
    float hp;
    float mp;
    private Animator animator;
    bool wait = false;
    // Use this for initialization
    void Start () {
        this.animator = GetComponent<Animator>();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sound01 = audioSources[0];
        sound02 = audioSources[1];
        sound03 = audioSources[2];
        status =GetComponent<Status>();


    }
	
	// Update is called once per frame
	void Update () {
        hp = status.HP;
        mp = status.MP; 
        //Debug.Log(hp);
        if (this.isAButtonClick) {
            this.animator.SetBool("Jump", true);
            //Invoke("Call", 2f);
            CommandPanel.SetActive(false);
            GameObject.Find("MessageText").GetComponent<Text>().text = "ウニの攻撃";
            //Debug.Log("攻撃");
            sound02.PlayDelayed(1);
            Invoke("EnemyTurn", 2.5f);
            Invoke("EnemyDamage", 1f);
            this.isAButtonClick = false;

        }
        if (this.isSButtonClick) {
            this.isSButtonClick = false;
            CommandPanel.SetActive(false);
                SkilPanel.SetActive(true);
        }
        if (this.isBackButtonClick) {
            this.isBackButtonClick = false;
            CommandPanel.SetActive(true);
                SkilPanel.SetActive(false);
        }
        if (this.isSkilButtonClick) {         
            if (mp >= 5) { 
            status.MP -= 5;
            GameObject.Find("MessageText").GetComponent<Text>().text = "ウニは魔法をとなえた";
            this.isSkilButtonClick = false;
            this.animator.SetBool("Skil1", true);
            GameObject.Find("Flame").GetComponent<ParticleSystem>().Play();
            sound01.PlayDelayed(1);
            SkilPanel.SetActive(false);
            GameObject.Find("FlameAura").GetComponent<ParticleSystem>().Play();
            FlamePanel.SetActive(false);
            Invoke("EnemyTurn", 4.5f);
            Invoke("EnemySkil1Damage", 3f);
                GameObject.Find("MPText").GetComponent<Text>().text = "" + status.MP;
            } else {
                Debug.Log("MPがたりません");
            }
        }
        if (this.isSkil2ButtonClick) {
            if (mp >= 10) {
             status.MP -= 10;   
            GameObject.Find("MessageText").GetComponent<Text>().text = "ウニは魔法をとなえた";
            this.isSkil2ButtonClick = false;
            this.animator.SetBool("Skil2", true);
            SkilPanel.SetActive(false);
            GameObject.Find("Unown").GetComponent<ParticleSystem>().Play();
            sound03.PlayDelayed(1.5f);
            GameObject.Find("UnownAura").GetComponent<ParticleSystem>().Play();
            Invoke("EnemyTurn", 4.5f);
            Invoke("EnemySkil2Damage", 3f);
                GameObject.Find("MPText").GetComponent<Text>().text = "" + status.MP;
            }
            else {
                Debug.Log("MPがたりません");
            }
        }

        if (wait == true) {
            this.animator.SetBool("Wait", true);
            Invoke("Call1", 0.1f);
        }
        if (this.isTitleButtonClick) {
            SceneManager.LoadScene("taitoru");
            this.isTitleButtonClick = false;
        }
    }
   
    public void GetMyAttackBottonClick() {
        this.isAButtonClick = true; 
    }
    public void GetMySkilBottonClick() {
        this.isSButtonClick = true;
    }
    public void GetMyBackBottonClick() {
        this.isBackButtonClick = true;
    }
    public void GetMySkil1ButtonClick() {
        this.isSkilButtonClick = true;      
    }
    public void GetMySkil2ButtonClick() {
        this.isSkil2ButtonClick = true;      
    }
    public void GetMySkil1ButtonEnter() {
        this.isSkilButtonEnter = true;
        FlamePanel.SetActive(true);
    }
    public void GetMySkil1ButtonExit() {
        this.isSkilButtonEnter = false;
        FlamePanel.SetActive(false);
    }
    public void GetMyTitleBottonClick() {
        this.isTitleButtonClick = true;
    }
    void Call1() {        
        wait = false;
        this.animator.SetBool("Wait", false);
        animator.SetBool("Damage", false);
    }
    //void Call() {
        //this.animator.SetBool("Jump", false);
        //this.animator.SetBool("Skil1", false);
        //this.animator.SetBool("Skil2", false);
    //}
    void EnemyDamage() {
        GetComponent<Status>().Attack();
    }
    void EnemySkil1Damage() {
        GetComponent<Status>().Skil1();
    }
    void EnemySkil2Damage() {
        GetComponent<Status>().Skil2();
    }
    void EnemyTurn() {
        GetComponent<Status>().EnemyAttack();
        //Invoke("Damage", 1.5f);
    }
    public void Damage() {          
            animator.SetBool("Damage", true);
        Invoke("NextorDeath", 0.5f);
            Invoke("Call1", 0.1f);
              
    }
    void NextorDeath() {     
        if (hp > 0){
            Invoke("Next", 1.0f);
        } else if (hp <= 0) {
            hp = 0;
            animator.SetTrigger("death");
            Invoke("Stop", 1);           
        }
        GameObject.Find("HPText").GetComponent<Text>().text = "" + hp;
    }
    void Next() {      
        CommandPanel.SetActive(true);
        wait = true;
        GameObject.Find("MessageText").GetComponent<Text>().text = "";
        GameObject.Find("MessageTextunder").GetComponent<Text>().text = "";

    }
    void Stop() {
        GameObject.Find("MessageText").GetComponent<Text>().text = "ウニはちからつきた";
        GameObject.Find("MessageText").GetComponent<Text>().color = Color.red;
        GameObject.Find("MessageTextunder").GetComponent<Text>().text = "";
        animator.SetFloat("MovingSpeed", 0.0f);
        GameObject.Find("BBGM").GetComponent<AudioSource>().enabled = false;
        GameObject.Find("BossBGM").GetComponent<AudioSource>().enabled = false;
        GameObject.Find("GameOverBGM").GetComponent<AudioSource>().Play();
        Invoke("Title", 6f);
    }
    void Title() {
        TitleButton.SetActive(true);
    }
}
