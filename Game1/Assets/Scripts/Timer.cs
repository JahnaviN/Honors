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

    private string id = Login.id;

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
			saveScore ();
        }
        time -= Time.deltaTime;

        var seconds = time % 60;
        var fraction = (time * 100) % 100;

        timerLabel.text = string.Format("{0:00} : {1:000}", seconds, fraction);
    }

    private void saveScore()
    {
        string filePath = Application.dataPath + "/CSV/" + "Scores.csv";
        string[] arr = File.ReadAllLines(filePath);
        for (int index = 0; index < arr.Length; index++)
        {
            string[] parts = arr[index].Split(new char[] { ',' });
            if (parts[0].Equals(id.ToString()))
            {
                string scene = SceneManager.GetActiveScene().name;
                parts[dict[scene]] = score.text;
                string total = scene.Split(new char[] { '_' })[0] + "_total";

                for (int i = 1; i <= 5; i++)
                {
                    string str = scene.Split(new char[] { '_' })[0] + "_Q" + i.ToString();
                    if (i == 1)
                        parts[dict[total]] = Int32.Parse(parts[dict[str]]).ToString();
                    else if (!parts[dict[str]].Equals("-"))
                        parts[dict[total]] = (Int32.Parse(parts[dict[total]]) + Int32.Parse(parts[dict[str]])).ToString();
                }

                var delimiter = ",";
                var sb1 = new StringBuilder();
                sb1.Append(string.Join(delimiter, parts));
                arr[index] = sb1.ToString();
                File.WriteAllLines(filePath, arr);

                getMistakes();

                string[] split = scene.Split(new char[] { 'Q' });
                int nxtq = Int32.Parse(split[1]) + 1;
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

    private void getMistakes()
    {
        string op = "";
        for(int i=1; i<=5; i++)
        {
            string p1 = "slot";
            var item = GameObject.FindGameObjectWithTag(p1+i.ToString());
            if (item.transform.childCount != 0)
            {
                var child = item.transform.GetChild(0);
                if (child.tag != i.ToString())
                {
                    op += child.tag.ToString() + ";";
                }
                else
                    op += "c;";
            }
            else
                op = op + "n;";
        }

        if (op == null)
            return;

        string filePath = Application.dataPath + "/CSV/" + "mistakes.csv";
        string[] arr = File.ReadAllLines(filePath);

        Dictionary<string, int> mDict = new Dictionary<string, int>();
        string[] parts = arr[0].Split(new char[] { ',' });
        for (int index = 0; index < parts.Length; index++)
        {
            if (!mDict.ContainsKey(parts[index]))
                mDict[parts[index]] = index;
        }

        for (int index = 1; index < arr.Length; index++)
        {
            parts = arr[index].Split(new char[] { ',' });
            if (parts[0].Equals(id.ToString()))
            {
                string scene = SceneManager.GetActiveScene().name;
                parts[mDict[scene]] = op;

                var delimiter = ",";
                var sb1 = new StringBuilder();
                sb1.Append(string.Join(delimiter, parts));
                arr[index] = sb1.ToString();
                File.WriteAllLines(filePath, arr);
                break;
            }
        }
    }
}
