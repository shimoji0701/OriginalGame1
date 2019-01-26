using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Status2 : MonoBehaviour {
    public static float HP;
    public static int MP;
    float Power ;     //ステータス
    int skil1;
    int skil2;
    public static float  Weapon; //初期武器防具
    public static float Armor;
    float Weapon2;
    float Armor2;
    public float BossHP;
    public float BossPower;
    public float EHP ;　//敵ステータス
    float EnemyPower;
    //public static 
    private Animator Eanimator;
    private Animator animator;
    private Animator BosAni;
    [SerializeField] private GameObject FieldButton;
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject SubCamera;
    [SerializeField] private GameObject BossCamera;
    [SerializeField] private GameObject BattleCanvas;
    [SerializeField] private GameObject CommandPanel;
    private bool isFieldButtonClick = false;
    private GameObject BattleEnemy;
    private GameObject comPanel;
    ChangeCamera2 chanCame;
    bool Boss;
    // Use this for initialization
    void Start () {
        Weapon = 1;
        Armor = 1;
        HP = 100;
        MP = 15;
        EHP = 91;
        BossPower = 1;
        BossHP = 390;
        chanCame = GameObject.Find("unitychan").GetComponent<ChangeCamera2>();
       
        this.animator = GetComponent<Animator>();
        this.Eanimator = GameObject.Find("BattleEnemy").GetComponent<Animator>();
        this.BattleEnemy = GameObject.Find("BattleEnemy");
        this.comPanel = GameObject.Find("CommandPanel");
        BosAni = GameObject.Find("BattleBoss").GetComponent<Animator>();
        Weapon2 = Status.getA();
        Weapon = Weapon2;
        Armor2 = Status.getB();
        Armor = Armor2;
        Debug.Log("Weapon" + Weapon);
        Debug.Log("Armor" + Armor);
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Weapon);
        Boss = chanCame.boss;
        if(Boss == true) {
            BossPower = 2.0f;
        }
        //Debug.Log(Boss);
        //フィールドに戻る
        if (isFieldButtonClick) {
            GameObject.Find("MessageText").GetComponent<Text>().text = "";
            GameObject.Find("MessageText").GetComponent<Text>().fontSize = 15;
            //comPanel.SetActive(true);
            CommandPanel.SetActive(true);
            isFieldButtonClick = false;
            FieldButton.SetActive(false);
            animator.SetBool("Win", false);
            MainCamera.SetActive(true);
            SubCamera.SetActive(false);
            BossCamera.SetActive(false);
            BattleCanvas.SetActive(false);
            GameObject.Find("unitychan").GetComponent<CharacterController>().enabled = true;
            GameObject.Find("FadeCanvas").GetComponent<FadeImage>().Range = 0;
            EHP = 91;
            BattleEnemy.SetActive(true);
            transform.eulerAngles = new Vector3(0, 0f, 0);
            Eanimator.SetTrigger("Rev");
            transform.position = new Vector3(64.35f, 0f, 198.55f);

        }                   
            //if (HP<31) {
            //GameObject.Find("ParamPanel").GetComponent<Image>().color = Color.yellow;
           //}else if(HP <= 0) {
                //GameObject.Find("ParamPanel").GetComponent<Image>().color = Color.red;
            //}else{       
        //GameObject.Find("ParamPanel").GetComponent<Image>().color = Color.white;
            //}
    }
    public void Attack() {//攻撃              
        this.Power = Mathf.Round(Random.Range(30, 36) * Weapon) ;
        GameObject.Find("MessageTextunder").GetComponent<Text>().text = this.Power + "のダメージを与えた";      
        if(Boss == false) {  //通常敵の場合
            EHP -= Power;
            if (EHP > 0) {
                Eanimator.SetTrigger("Damage");
                Invoke("okure", 0.8f);
                
            }else if (EHP <= 0) {
                Eanimator.SetTrigger("Death");
            }
        }
        else if(Boss == true) {　//ボスの場合
            BossHP -= Power;
            if (BossHP> 0) {   //ボスのHPに応じてのアニメーション
                BosAni.SetTrigger("Damage");
                BosAni.SetTrigger("damage");
            }else if(BossHP <= 0) {
                BosAni.SetTrigger("Death");
            }                    
        }                    
    }
    public void Skil1() {   //魔法1Flame        
        this.skil1 = Random.Range(91, 96);
        GameObject.Find("MessageTextunder").GetComponent<Text>().text = this.skil1 + "のダメージを与えた";
        if(Boss == false) {
            EHP -= skil1;
            if (EHP > 0) {
                Eanimator.SetTrigger("Damage");
                Invoke("okure", 0.8f);
            }
            else if (EHP <= 0) {
                Eanimator.SetTrigger("Death");
            }
        }else if(Boss == true) {
            BossHP -= skil1;
            if (BossHP> 0) {   
                BosAni.SetTrigger("Damage");
                BosAni.SetTrigger("damage");
            }else if(BossHP <= 0) {
                BosAni.SetTrigger("Death");
            }                    
        }                    
    }
    public void Skil2() {     //魔法2 Unknow   
            this.skil2 = Random.Range(130, 141);
            GameObject.Find("MessageTextunder").GetComponent<Text>().text = this.skil2 + "のダメージを与えた";           
        if (Boss == false){
            EHP -= skil2;
            if (EHP > 0) {
                Eanimator.SetTrigger("Damage");
                Invoke("okure", 0.8f);
            }
            else if (EHP <= 0) {
                Eanimator.SetTrigger("Death");
            }
        } else if(Boss == true) {　
            BossHP -= skil2;
            if (BossHP> 0) {   
                BosAni.SetTrigger("Damage");
                BosAni.SetTrigger("damage");
            }else if(BossHP <= 0) {
                BosAni.SetTrigger("Death");
            }                    
        }                    
    }
    public void EnemyAttack() {
        if(Boss == false) { 
        if (EHP > 0) { 
        Eanimator.SetBool("Attack", true);
        Invoke("Call1",0.6f);
        Invoke("Call2", 2f);
        Invoke("Call3", 2.5f);
                GameObject.Find("BattleEnemy").GetComponent<AudioSource>().PlayDelayed(1.3f);
                GameObject.Find("MessageText").GetComponent<Text>().text = "スカルの攻撃";
            GameObject.Find("MessageTextunder").GetComponent<Text>().text ="";
            this.animator.SetBool("Jump", false);
            this.animator.SetBool("Skil1", false);
            this.animator.SetBool("Skil2", false);
            Invoke("Damage", 1.5f);
                transform.position = new Vector3(64.35f, 0f, 198.55f);
            }
        else if(EHP <= 0) {
           
            GameObject.Find("MessageText").GetComponent<Text>().text = "スカルをたおした";
            GameObject.Find("MessageText").GetComponent<Text>().fontSize = 19;
            GameObject.Find("MessageTextunder").GetComponent<Text>().text = "";
            Debug.Log("敵を倒した");
            animator.SetBool("Win", true);
            transform.eulerAngles = new Vector3(0, 105f, 0);
            GameObject.Find("BBGM").GetComponent<AudioSource>().enabled = false;
            GameObject.Find("WinBGM").GetComponent<AudioSource>().Play();
            Invoke("FieldBack", 3f);
            }
        }else if(Boss == true) {
            if (BossHP > 0) {
                BosAni.SetTrigger("Attack");
                Invoke("Move1", 2.5f);
                GameObject.Find("MessageText").GetComponent<Text>().text = "ゴーレムの攻撃";
                GameObject.Find("MessageTextunder").GetComponent<Text>().text = "";
                this.animator.SetBool("Jump", false);
                this.animator.SetBool("Skil1", false);
                this.animator.SetBool("Skil2", false);
                Invoke("Damage", 1.5f);
                transform.position = new Vector3(215.8f, 0f, 212.6f);
                GameObject.Find("BattleBoss").GetComponent<AudioSource>().PlayDelayed(1.5f);
            }else if(BossHP<= 0) {
                
                GameObject.Find("MessageText").GetComponent<Text>().text = "ゴーレムをたおした";
                GameObject.Find("MessageText").GetComponent<Text>().fontSize = 19;
                GameObject.Find("MessageTextunder").GetComponent<Text>().text = "";
                Debug.Log("敵を倒した");
                animator.SetBool("Win", true);
                transform.eulerAngles = new Vector3(0, 105f, 0);
                GameObject.Find("BossBGM").GetComponent<AudioSource>().enabled = false;
                GameObject.Find("WinBGM").GetComponent<AudioSource>().Play();
                Invoke("FieldBack", 3f);
            }
        }
    }
    void Call1() {
        Eanimator.SetBool("Attack", false);
        
    }
    void Call2() {
        Eanimator.SetBool("Back", true);
    }
    void Call3() {
        Eanimator.SetBool("Back", false);
    }
    void okure() {
        Eanimator.SetTrigger("damage");
    }   
    void Move1() {
        BosAni.SetTrigger("Idle");
    }
    void Damage() {
        GetComponent<Battle2>().Damage();
        EnemyPower = Mathf.Round(Random.Range(13, 17) * BossPower * Armor);
        GameObject.Find("MessageTextunder").GetComponent<Text>().text = EnemyPower + "のダメージを受けた";
        Debug.Log(EnemyPower + "のダメージを受けた");       
        HP -= EnemyPower;
    }
    void FieldBack() {
        GameObject.Find("BGM").GetComponent<AudioSource>().enabled = true;
        FieldButton.SetActive(true);
        this.animator.SetBool("Jump", false);
        this.animator.SetBool("Skil1", false);
        this.animator.SetBool("Skil2", false);
    }
    public void GetMyFieldBottonClick() {
        isFieldButtonClick = true; 
    }
    public static float getA(){
		return Weapon;
	}
    public static float getB(){
		return Armor;
	}
    public static float getC(){
		return HP;
	}
    
}
