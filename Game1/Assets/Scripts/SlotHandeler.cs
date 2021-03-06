﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;

public class SlotHandeler : MonoBehaviour, IDropHandler {

	//public static Dictionary<string, int> dict = new Dictionary<string, int> ();

	public static Dictionary<string, int> dict = new Dictionary<string, int>()
	{
		{"ID",0},
		{"Level_Stat",1},
		{"Q_stat",2},
        {"L0_Q1",3},
        {"L0_Q2",4},
        {"L0_Q3",5},
        {"L0_Q4",6},
        {"L0_Q5",7},
        {"L0_total",8},
        {"L1_Q1",9},
		{"L1_Q2",10},
		{"L1_Q3",11},
		{"L1_Q4",12},
		{"L1_Q5",13},
		{"L1_total",14},
		{"L2_Q1",15},
		{"L2_Q2",16},
		{"L2_Q3",17},
		{"L2_Q4",18},
		{"L2_Q5",19},
		{"L2_total",20},
		{"L3_Q1",21},
		{"L3_Q2",22},
		{"L3_Q3",23},
		{"L3_Q4",24},
		{"L3_Q5",25},
		{"L3_total",26},
		{"L4_Q1",27},
		{"L4_Q2",28},
		{"L4_Q3",29},
		{"L4_Q4",30},
		{"L4_Q5",31},
		{"L4_total",32},
		{"L5_Q1",33},
		{"L5_Q2",34},
		{"L5_Q3",35},
		{"L5_Q4",36},
		{"L5_Q5",37},
		{"L5_total",38}
	};

    public Text score;

	private string id = Login.id;

    void Start()
    {
        score.text = 0.ToString();
    }

	public GameObject item
    {
        get
        {
            if(transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(!item)
        {
            Transform prevParent = DragHandeler.itemBeingDragged.transform.parent;
            DragHandeler.itemBeingDragged.transform.SetParent(transform);
            Transform nowParent = DragHandeler.itemBeingDragged.transform.parent;
            string tag = "slot" + DragHandeler.itemBeingDragged.tag;
            Debug.Log(tag);
            Debug.Log(nowParent.tag.ToString());
            if(tag == nowParent.tag)
            {
                score.text = (Int32.Parse(score.text) + 20).ToString();
            }
            else if(tag == prevParent.tag)
            {
                score.text = (Int32.Parse(score.text) - 20).ToString();
            }

			if (Int32.Parse (score.text) == 100) {
				saveScore ();
			}
        }
    }

	private void saveScore()
	{
        // string filePath = Application.dataPath + "/CSV/" + "Scores.csv";
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/CSV/" + "Scores.csv";
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

                string[] split = scene.Split(new char[] { 'Q' });
                int nxtq = Int32.Parse(split[1])+1;
                string nxtScene = null;
                if (nxtq <= 5)
                    nxtScene = split[0] + "Q" + nxtq.ToString();
                else {
                    var s = split[0].Split(new char[] { 'L', '_' });
                    nxtScene = "Level" + (Int32.Parse(s[1]) + 1).ToString();
                }
				if (nxtScene == "Level6")
					SceneManager.LoadScene ("Login");
				else
					SceneManager.LoadScene(nxtScene);
                break;
			}
		}
	}
}
