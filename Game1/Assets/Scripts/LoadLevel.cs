using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class LoadLevel : MonoBehaviour {

    public void OnClick()
    {
        string scene = SceneManager.GetActiveScene().name;
        int levelNo = Int32.Parse(scene.Split(new char[] { 'l' })[1]);
        string nxtScene = "L" + levelNo.ToString() + "_Q1";
        SceneManager.LoadScene(nxtScene);
    }
}
