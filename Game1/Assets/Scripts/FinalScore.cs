using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class FinalScore : MonoBehaviour {

	public Text txt;
	private Dictionary<string, int> dict = SlotHandeler.dict ;

	// Use this for initialization
	void Start () {

//		var id = 1;
//		string filePath = Application.dataPath + "/CSV/" + "Scores.csv";
//		string[] arr = File.ReadAllLines (filePath);
//		for (int index = 0; index < arr.Length; index++) {
//			string[] parts = arr[index].Split (new char[] {','});
//			if ( parts[0].Equals (id.ToString ())) {
//				txt.text = parts[dict["L1_total"]] ;
//				}	
//				break;
//			}
//		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
