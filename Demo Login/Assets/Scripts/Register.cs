using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;

public class Register : MonoBehaviour {

    public GameObject username;
    public GameObject email;
    public GameObject password;
    public GameObject confpassword;

    private string Username;
    private string Email;
    private string Password;
    private string Confpassword;
    private string Form;
    private bool EmailValid = false;

	// Use this for initialization
	void Start () {
	
	}
	
    public void RegisterButton()
    {
        Debug.Log("Registration is successful");
    }
	// Update is called once per frame
	void Update () {

        if ( Input.GetKeyDown(KeyCode.Tab))
        {
            if( username.GetComponent<InputField>().isFocused)
            {
                email.GetComponent<InputField>().Select();
            }
            if (email.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }
            if (password.GetComponent<InputField>().isFocused)
            {
                confpassword.GetComponent<InputField>().Select();
            }
        }

        if ( Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if( Password != "" && Email != "" && Password != "" && Confpassword != "" )
            {
                RegisterButton();
            }
        }

        Username = username.GetComponent<InputField>().text;
        Email = email.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        Confpassword = confpassword.GetComponent<InputField>().text;



    }
}
