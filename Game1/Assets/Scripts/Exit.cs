﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

	public void Onclick(){
		SceneManager.LoadScene ("Login");
	}
		
}
