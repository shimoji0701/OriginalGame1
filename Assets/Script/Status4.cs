using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Status4 : MonoBehaviour {
    public static float HP;
    public static int MP;
    float Power ;     //ステータス
    int skil1;
    int skil2;
    public static float  Weapon; //初期武器防具
    public static float Armor;
    float Weapon4;
    float Armor4;
    bool SMP;
    bool SHP;

    public float BossHP;
    public float BossPower;
    public float EHP ;　//敵ステータス
    float EnemyPower;
    //public static 
    private Animator Eanimator;
    private Animator animator;
    
    Animation anim;
    [SerializeField] private GameObject FieldButton;
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject SubCamera;
    [SerializeField] private GameObject BossCamera;
    [SerializeField] private GameObject BattleCanvas;
    [SerializeField] private GameObject CommandPanel;
    private bool isFieldButtonClick = false;
    private GameObject BattleEnemy;
    private GameObject comPanel;
    private GameObject LastBoss;
    ChangeCamera4 chanCame;
    bool Boss;
    // Use this for initialization
    void Start () {
        Weapon = 1;
        Armor = 1;
        HP = 100;
        MP = 15;
        EHP = 95;
        BossPower = 1;
        BossHP = 700;
        chanCame = GameObject.Find("unitychan").GetComponent<ChangeCamera4>();
        anim = GameObject.Find("LastBoss").gameObject.GetComponent<Animation>();
        this.animator = GetComponent<Animator>();
        this.Eanimator = GameObject.Find("BattleEnemy").GetComponent<Animator>();
        this.BattleEnemy = GameObject.Find("BattleEnemy");
        this.comPanel = GameObject.Find("CommandPanel");
        LastBoss = GameObject.Find("LastBoss");
        Weapon4 = Status3.getA();
        Weapon = Weapon4;
        Armor4 = Status3.getB();
        Armor = Armor4;
        SMP = Item2.getI();
        SHP = Item3.getI();
       if(SMP ==true) {
            MP = 25;
        }
        if(SHP == true) {
            HP = 200;
        }
        Debug.Log("Weapon" + Weapon);
        Debug.Log("Armor" + Armor);
        Debug.Log(HP);
        Debug.Log(MP);
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Weapon);
        Boss = chanCame.boss;
        if(Boss == true) {
            BossPower = 2.6f;
        }
        //Debug.Log(Boss);
        //フィールドに戻る
        if (isFieldButtonClick) {
            SceneManager.LoadScene("End");

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
                
            }else if(BossHP <= 0) {
               
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

               
            }else if(BossHP <= 0) {
                
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
                
               
            }else if(BossHP <= 0) {
              
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
                transform.position = new Vector3(-235.7f, 0f, 228.5f);
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
                anim.Play("Attack");
                Invoke("Move1", 1.6f);
                GameObject.Find("MessageText").GetComponent<Text>().text = "サムライの攻撃";
                GameObject.Find("MessageTextunder").GetComponent<Text>().text = "";
                this.animator.SetBool("Jump", false);
                this.animator.SetBool("Skil1", false);
                this.animator.SetBool("Skil2", false);
                Invoke("Damage", 1.5f);
                transform.position = new Vector3(-211.1f, 0f, 225.1f);
                GameObject.Find("LastBoss").GetComponent<AudioSource>().PlayDelayed(1.4f);
            }else if(BossHP<= 0) {
                
                GameObject.Find("MessageText").GetComponent<Text>().text = "サムライをたおした";
                GameObject.Find("MessageText").GetComponent<Text>().fontSize = 19;
                GameObject.Find("MessageTextunder").GetComponent<Text>().text = "";
                Debug.Log("敵を倒した");
                Destroy(LastBoss);
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
        anim.Play();
    }
    void Damage() {
        GetComponent<Battle4>().Damage();
        EnemyPower = Mathf.Round(Random.Range(18, 22) * BossPower * Armor);
        GameObject.Find("MessageTextunder").GetComponent<Text>().text = EnemyPower + "のダメージを受けた";
        Debug.Log(EnemyPower + "のダメージを受けた");       
        HP -= EnemyPower;
    }
    void FieldBack() {
        
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
    public static int getD(){
		return MP;
	}
}
