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
    private string form;
    private int Score = 0;

    private List<string[]> rowData = new List<string[]>();
    //private bool EmailValid = false;

    // Use this for initialization
    //void Start () {

    //}

    public void RegisterButton()
    {
        bool UN = false;
        bool EM = false;
        bool PW = false;
        bool CPW = false;
        //bool Check = false;

        /*  if (!System.IO.File.Exists(@"C:\Users\Nithiya Shree\Documents\Unity Games\UNITY_DATABASE\Data.xlsx"))
          {
              Check = false;
          }
          else
          {
              Check = true;
          } */

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

        /*  if ( Username != "")
          {
              if ( !System.IO.File.Exists(@"C:\Users\Nithiya Shree\Documents\Unity Games\UNITY_DATABASE\" + Username+".txt"))
              {
                  UN = true;
              }
              else
              {
                  Debug.LogWarning("Username taken and no file pr");
              }
          }
          else
          {
              Debug.LogWarning("Username Field Empty.");
          } 

        if ( Email != "")
        {
            EM = true;
            
            if( EmailValid)
            {
                if ( Email.Contains("@"))
                {
                    if (Email.Contains("."))
                    {
                        EM = true;
                    }
                    else
                    {
                        Debug.LogWarning(" Email is incorrect.");
                    }
                }
                else
                {
                    Debug.LogWarning(" Email is incorrect.");
                }
            }
            else
            {
                Debug.LogWarning(" Email is incorrect");
            } 
        }
        else
        {
            Debug.LogWarning(" Email field empty.");
        } */

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
            //form = (Username + Environment.NewLine + Email + Environment.NewLine + Password);
            //System.IO.File.WriteAllText(@"C:\Users\Nithiya Shree\Documents\Unity Games\UNITY_DATABASE\" + Username + ".txt", form);
            save1();

            username.GetComponent<InputField>().text = "";
            email.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            confPassword.GetComponent<InputField>().text = "";
            print(" Registration Successful.");
        }
    }

    void save()
    {
        // Creating First row of titles manually..
        string[] rowDataTemp = new string[3];
        //rowDataTemp[0] = "UserName";
        //rowDataTemp[1] = "Email";
        //rowDataTemp[2] = "Password";
        //rowData.Add(rowDataTemp);

        // You can add up the values in as many cells as you want.
        /* for (int i = 0; i < 10; i++)
         {
             rowDataTemp = new string[3];
             rowDataTemp[0] = "Sushanta" + i; // name
             rowDataTemp[1] = "" + i; // ID
             rowDataTemp[2] = "$" + UnityEngine.Random.Range(5000, 10000); // Income
             rowData.Add(rowDataTemp);
         } */

        rowDataTemp = new string[3];
        rowDataTemp[0] = Username;
        rowDataTemp[1] = Email;
        rowDataTemp[2] = Password;
        rowData.Add(rowDataTemp);

        string[][] output = new string[rowData.Count][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = rowData[i];
        }

        int length = output.GetLength(0);
        string delimiter = ",";

        StringBuilder sb = new StringBuilder();

        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));

        string filePath = getPath();

        File.AppendAllText(filePath, sb.ToString());

        /* StreamWriter outStream = System.IO.File.CreateText(filePath);
        outStream.WriteLine(sb);
        outStream.Close(); */
    }

    void save1()
    {
        string filePath = getPath();
        string delimiter = ",";

        if ( !System.IO.File.Exists(filePath))
        {
            string[][] output1 = new string[][]{
             new string[]{ "Username", "Email", "Password"},
            };
            int length1 = output1.GetLength(0);
            StringBuilder sb1 = new StringBuilder();
            for (int index = 0; index < length1; index++)
                sb1.AppendLine(string.Join(delimiter, output1[index]));

            File.AppendAllText(filePath, sb1.ToString());
            //var linesnit = File.ReadAllLines(filePath).Count();
            //print linesnit;
        }

        string[][] output = new string[][]{
             new string[]{ Username, Email, Password},
         };
        int length = output.GetLength(0);
        StringBuilder sb = new StringBuilder();
        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));

        //File.WriteAllText(filePath, sb.ToString());
        File.AppendAllText(filePath, sb.ToString());
        var lineCount1 = File.ReadAllLines(filePath);
        //print lineCount1;
        Debug.Log(lineCount1);
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