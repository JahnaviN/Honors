using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class FinalScore : MonoBehaviour {

	public Text score;
	private Dictionary<string, int> dict = SlotHandeler.dict ;
	private string id = Login.id;

    // Use this for initialization
    void Start()
    {
        string filePath = Application.dataPath + "/CSV/" + "Scores.csv";
        string[] arr = File.ReadAllLines(filePath);
        for (int index = 0; index < arr.Length; index++)
        {
            string[] parts = arr[index].Split(new char[] { ',' });
            Debug.Log(parts[0]);
            if (parts[0].Equals(id.ToString()))
            {
                score.text = "YOUR SCORE  :  " + parts[dict["L1_total"]];
                break;
            }
        }
    }
}
