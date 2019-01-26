using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCamera3 : MonoBehaviour {
    //　メインカメラ
    [SerializeField] private GameObject MainCamera;
    //　切り替える他のカメラ
    [SerializeField] private GameObject SubCamera;
    [SerializeField] private GameObject BossCamera;

    [SerializeField] private GameObject BattleCanvas;
    private CharacterController controller;
    bool fadein = false;
    bool fadeout = false;
    private GameObject BHeroPos;
    private GameObject S1;
    private GameObject S1Aura;
    private GameObject S2;
    private GameObject S2Aura;
    public bool boss ;
    Status3 status;
    // Use this for initialization
    void Start () {
        boss = false;
        controller = GetComponent<CharacterController>();
        BHeroPos = GameObject.Find("BattleHero");
        S1 = GameObject.Find("Flame");
        S1Aura = GameObject.Find("FlameAura");
        S2 = GameObject.Find("Unown");
        S2Aura = GameObject.Find("UnownAura");
        status = GameObject.Find("BattleHero").GetComponent<Status3>();
    }     

    // Update is called once per frame
    void Update(){     
        if (fadein == true && fadeout ==false && GameObject.Find("FadeCanvas").GetComponent<FadeImage>().Range <= 1) {
            GameObject.Find("FadeCanvas").GetComponent<FadeImage>().Range += 0.05f;
           if(GameObject.Find("FadeCanvas").GetComponent<FadeImage>().Range >= 1) {
                fadeout = true;
            }
        }else if(fadein == true && GameObject.Find("FadeCanvas").GetComponent<FadeImage>().Range >= 0) {
            Invoke("Call1",1.5f);

        }
        
        
        //　1キーを押したらカメラの切り替えをする(後に戦闘終了時に変える）
        if (Input.GetKeyDown("1")){
           MainCamera.SetActive(true);
           SubCamera.SetActive(false);
            controller.enabled = true;
            GameObject.Find("BGM").GetComponent<AudioSource>().enabled = true;
            GameObject.Find("BBGM").GetComponent<AudioSource>().enabled = false;
            BattleCanvas.SetActive(false);
            
            GameObject.Find("FadeCanvas").GetComponent<FadeImage>().Range = 0;
        }
        
    }
void OnTriggerStay(Collider col) {
        //敵(Enemyタグ)に衝突したとき
		if(col.tag == "Enemy") {
            Invoke("Call15", 1.5f);
            Invoke("Call2", 2f);
            Invoke("Call3", 3f);
            Debug.Log("敵に衝突");
            controller.enabled = false;
            GameObject.Find("BGM").GetComponent<AudioSource>().enabled = false;
            fadein = true;
            GameObject.Find("unitychan").GetComponent<AudioSource>().Play();
            Destroy(col.gameObject);
            boss = false;
        }
        if(col.tag == "Boss") {
            Invoke("CamerachangeB", 1.5f);
            Invoke("BGMB", 2f);
            Invoke("Call3", 3f);
            Debug.Log("Bossに衝突");
            controller.enabled = false;
            GameObject.Find("BGM").GetComponent<AudioSource>().enabled = false;
            fadein = true;
            GameObject.Find("unitychan").GetComponent<AudioSource>().Play();
            BHeroPos.transform.position = new Vector3(-211.1f, 0f, 255.1f);
            //S1.transform.position = new Vector3(-88.5f, -0.5f, -132f);
            //S1Aura.transform.position = new Vector3(-88.8f, 1.38f, -138.4f);
            //S2.transform.position = new Vector3(-89f, 1.84f, -132f);
            //S2Aura.transform.position = new Vector3(-88.5f, 1.7f, -138.46f);
            Destroy(col.gameObject);
            boss = true;
        }
    }
    void Call15() {
         MainCamera.SetActive(false);
         SubCamera.SetActive(true);        
    }
    void Call2() {
        GameObject.Find("BBGM").GetComponent<AudioSource>().enabled = true;
    }
    void CamerachangeB() {
        MainCamera.SetActive(false);
        BossCamera.SetActive(true);
    }
    void BGMB() {
        GameObject.Find("BossBGM").GetComponent<AudioSource>().enabled = true;
    }
    void Call1() {
        GameObject.Find("FadeCanvas").GetComponent<FadeImage>().Range -= 0.05f;
    }
    void Call3() {
        BattleCanvas.SetActive(true);
        GameObject.Find("HPText").GetComponent<Text>().text = "" + Status3.HP;
        GameObject.Find("MPText").GetComponent<Text>().text = "" + Status3.MP;
        fadein = false;
        fadeout = false;
    }
}

