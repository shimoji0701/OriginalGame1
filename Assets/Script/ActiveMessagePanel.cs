using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ActiveMessagePanel : MonoBehaviour {
 
	//　MessageUIに設定されているMessageスクリプトを設定
	[SerializeField]
	private Message messageScript;
 
	//　表示させるメッセージ
	private string message = "かかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかか"
	                         + "ききききききききききききききききききききききききききききききききききききききききききききききききききききききき\n"
	                         + "くくくくく\n"
	                         + "けけけけけけけけけけけけ";
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("5")) {
			messageScript.SetMessagePanel (message);
		}
	}
}