using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text.RegularExpressions;

public class Login : MonoBehaviour {

    public GameObject username;
    public GameObject password;

    private string Username;
    private string Password;
    private string[] Lines;

    // Update is called once per frame
    public void ChangeToScene(string sceneToChangeTo)
    {
        Application.LoadLevel(sceneToChangeTo);
    }

//    public void LoginButton()
//    {
//        bool UN = false;
//        bool PW = false;
//
//        string filePath = getPath();
//
//        if ( Username != "")
//        {
//            if ( System.IO.File.Exists(@"C:\Users\Nithiya Shree\Documents\Unity Games\UNITY_DATABASE\" + Username + ".txt"))
//            {
//                UN = true;
//                Lines = System.IO.File.ReadAllLines(@"C:\Users\Nithiya Shree\Documents\Unity Games\UNITY_DATABASE\" + Username + ".txt");
//            }
//            else
//            {
//                Debug.LogWarning(" Username Invalid.");
//            }
//        }
//        else
//        {
//            Debug.LogWarning(" Username field empty.");
//        }
//        
//        if ( Password != "")
//        {
//            if ( Password == Lines[2])
//            {
//                PW = true;
//            }
//            else
//            {
//                Debug.LogWarning(" Invalid password.");
//            }
//        }
//        else
//        {
//            Debug.LogWarning(" Password Field empty.");
//        }
//
//        if ( UN == true && PW == true)
//        {
//            username.GetComponent<InputField>().text = "";
//            password.GetComponent<InputField>().text = "";
//            print(" Login Successful");
//        }
//    }

	private void LoginButton()
	{
		bool ID = false;
		bool PW = false;

		string filePath = getPath ();

		if (!System.IO.File.Exists (filePath)) {
			Debug.Log ("User not registered");
			return;
		}

		var reader =  File.OpenText(filePath);

		string line;
		while (true) {
			line = reader.ReadLine ();
			if (line == null)
				break;
			string[] parts = line.Split (new char[] {','});
			if(parts[0].Equals(Username))
			{
				if (parts [3].Equals (Password)) {
					Debug.Log ("login successful");
				} else {
					Debug.Log ("password not equal");
				}
				break;
			}
		}
	}

    // To obtain the file path of the database file
    private string getPath()
    {
        return Application.dataPath + "/CSV/" + "Saved_data.csv";
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (username.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (Password != "" && Password != "")
            {
                LoginButton();
            }
        }

        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
    }
}
