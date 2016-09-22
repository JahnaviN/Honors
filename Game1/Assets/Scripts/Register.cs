using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;
using System.Text.RegularExpressions;

public class Register : MonoBehaviour {

    public GameObject username;
    public GameObject email;
    public GameObject password;
    public GameObject confPassword;

    private string Username;
    private string Email;
    private string Password;
    private string ConfPassword;

    public void RegisterButton()
    {
        bool UN = false;
        bool EM = false;
        bool PW = false;
        bool CPW = false;

        if (Username != "")
        {
            UN = true;
        }
        else
        {
            Debug.LogWarning(" Username field empty.");
        }

        if (Email != "")
        {
            EM = true;
        }
        else
        {
            Debug.LogWarning(" Email field empty.");
        }

        if (Password != "")
        {
            if (Password.Length > 5)
            {
                PW = true;
            }
            else
            {
                Debug.LogWarning("Password must be atleast 6 characters long.");
            }
        }
        else
        {
            Debug.LogWarning(" Password field empty.");
        }

        if (ConfPassword != "")
        {
            if (ConfPassword == Password)
            {
                CPW = true;
            }
            else
            {
                Debug.LogWarning(" Passwords dont match.");
            }
        }
        else
        {
            Debug.LogWarning(" Confirm Password field empty.");
        }

        if (UN == true && EM == true && PW == true && CPW == true)
        {
            save();

            username.GetComponent<InputField>().text = "";
            email.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            confPassword.GetComponent<InputField>().text = "";
            print(" Registration Successful.");
        }
    }

//	Saves details To a csv file
    void save()
    {
        string filePath = getPath();
        string delimiter = ",";
        // string fp = Application.dataPath + "/CSV/" + "Scores.csv";
        string fp = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/CSV/" + "Scores.csv";
		string[][] header;
		header = new string[][] {
			new string[] {
				"ID",
				"Level_Stat",
				"Q_stat",
                "L0_Q1",
                "L0_Q2",
                "L0_Q3",
                "L0_Q4",
                "L0_Q5",
                "L0_total",
                "L1_Q1",
				"L1_Q2",
				"L1_Q3",
				"L1_Q4",
				"L1_Q5",
				"L1_total",
				"L2_Q1",
				"L2_Q2",
				"L2_Q3",
				"L2_Q4",
				"L2_Q5",
				"L2_total",
				"L3_Q1",
				"L3_Q2",
				"L3_Q3",
				"L3_Q4",
				"L3_Q5",
				"L3_total",
				"L4_Q1",
				"L4_Q2",
				"L4_Q3",
				"L4_Q4",
				"L4_Q5",
				"L4_total",
				"L5_Q1",
				"L5_Q2",
				"L5_Q3",
				"L5_Q4",
				"L5_Q5",
				"L5_total",
			},
		};

        if (!System.IO.File.Exists(filePath))
        {
            string[][] output1 = new string[][]{
             new string[]{ "ID", "Username", "Age", "Password"},
            };
            int length1 = output1.GetLength(0);
            StringBuilder sb1 = new StringBuilder();
            for (int index = 0; index < length1; index++)
                sb1.AppendLine(string.Join(delimiter, output1[index]));

            File.AppendAllText(filePath, sb1.ToString());

			length1 = header.GetLength (0);
			sb1 = new StringBuilder();
			for (int index = 0; index < length1; index++)
				sb1.AppendLine(string.Join(delimiter, header[index]));

			File.AppendAllText(fp, sb1.ToString());
        }

		var id = File.ReadAllLines (filePath).Length;
        string[][] output = new string[][]{
			new string[]{ id.ToString(), Username, Email, Password},
         };
        int length = output.GetLength(0);
        StringBuilder sb = new StringBuilder();
        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));
		
        File.AppendAllText(filePath, sb.ToString());

		StringBuilder s = new StringBuilder ();
		for(int index = 0; index < header[0].Length; index++)
			header[0][index] = "-";
		header[0][0] = id.ToString();
		s.AppendLine(string.Join(delimiter,header[0]));
		File.AppendAllText (fp, s.ToString ());

        mistakes();
    }

    void mistakes()
    {
        // string filePath = Application.dataPath + "/CSV/" + "mistakes.csv";
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/CSV/" + "mistakes.csv";
        string delimiter = ",";
        // string fp = Application.dataPath + "/CSV/" + "Scores.csv";
        string[][] header;
        header = new string[][] {
            new string[] {
                "ID",
                "L0_Q1",
                "L0_Q2",
                "L0_Q3",
                "L0_Q4",
                "L0_Q5",
                "L1_Q1",
                "L1_Q2",
                "L1_Q3",
                "L1_Q4",
                "L1_Q5",
                "L2_Q1",
                "L2_Q2",
                "L2_Q3",
                "L2_Q4",
                "L2_Q5",
                "L3_Q1",
                "L3_Q2",
                "L3_Q3",
                "L3_Q4",
                "L3_Q5",
				"L4_Q1",
				"L4_Q2",
				"L4_Q3",
				"L4_Q4",
				"L4_Q5",
				"L5_Q1",
				"L5_Q2",
				"L5_Q3",
				"L5_Q4",
				"L5_Q5",
            },
        };

        if (!System.IO.File.Exists(filePath))
        {
            int length1 = header.GetLength(0);
            StringBuilder sb1 = new StringBuilder();
            for (int index = 0; index < length1; index++)
                sb1.AppendLine(string.Join(delimiter, header[index]));

            File.AppendAllText(filePath, sb1.ToString());
        }

        var id = File.ReadAllLines(filePath).Length;
        StringBuilder s = new StringBuilder();
        for (int index = 0; index < header[0].Length; index++)
            header[0][index] = "-";
        header[0][0] = id.ToString();
        s.AppendLine(string.Join(delimiter, header[0]));
        File.AppendAllText(filePath, s.ToString());
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
                email.GetComponent<InputField>().Select();
            }
            if (email.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }
            if (password.GetComponent<InputField>().isFocused)
            {
                confPassword.GetComponent<InputField>().Select();
            }
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (Password != "" && Email != "" && Password != "" && ConfPassword != "")
            {
                RegisterButton();
            }
        }

        Username = username.GetComponent<InputField>().text;
        Email = email.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        ConfPassword = confPassword.GetComponent<InputField>().text;
    }
}