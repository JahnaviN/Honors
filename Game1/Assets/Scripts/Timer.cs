using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System;

public class Timer : MonoBehaviour
{

    public Text timerLabel;

    private float time = 30;
		
	private Dictionary<string, int> dict = SlotHandeler.dict ;
	public Text score;

//	void Start(){
//		Debug.Log (dict.Count);
//	}

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
			saveScore ();
            SceneManager.LoadScene("Game_Over");
        }
        time -= Time.deltaTime;

        var seconds = time % 60;
        var fraction = (time * 100) % 100;

        timerLabel.text = string.Format("{0:00} : {1:000}", seconds, fraction);
    }

	private void saveScore()
	{
		var id = 1;
		string filePath = Application.dataPath + "/CSV/" + "Scores.csv";
		string[] arr = File.ReadAllLines (filePath);
		for (int index = 0; index < arr.Length; index++) {
			string[] parts = arr[index].Split (new char[] {','});
			if ( parts[0].Equals (id.ToString ())) {
				string scene = SceneManager.GetActiveScene ().name;
				parts[dict[scene]] = score.text;
				string total = scene.Split(new char[] {'_'})[0] + "_total";

				for (int i = 1; i <= 5; i++) {
					string str = scene.Split (new char[] { '_' }) [0] + "_Q" + i.ToString ();
					if(i == 1)
						parts[dict[total]] = Int32.Parse (parts[dict[str]]).ToString ();
					else if(!parts[dict[str]].Equals("-"))
						parts [dict [total]] = (Int32.Parse (parts [dict [total]]) + Int32.Parse (parts[dict[str]]) ).ToString ();
				}	

				var delimiter = ",";
				var sb1 = new StringBuilder();
				sb1.Append(string.Join(delimiter,parts));
				arr [index] = sb1.ToString ();
				File.WriteAllLines (filePath, arr);
				break;
			}
		}
	}
}
