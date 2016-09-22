using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {

    public GameObject username;
    public GameObject password;

    private string Username;
    private string Password;
    private string[] Lines;

	public static string id;

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
				ID = true;
				id = Username;
				if (parts [3].Equals (Password)) {
					PW = true;
					//Debug.Log ("login successful");
					SceneManager.LoadScene ("Level0");
				} else {
					Debug.Log ("password not equal");
				}
				break;
			}
		}
		if (PW == true && ID == true) {
			username.GetComponent<InputField> ().text = "";
			password.GetComponent<InputField> ().text = "";
		}
	}

    // To obtain the file path of the database file
    private string getPath()
    {
        // return Application.dataPath + "/CSV/" + "Saved_data.csv";
        return Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/CSV/" + "Saved_data.csv";
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
