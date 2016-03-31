using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class level1 : MonoBehaviour {

	public void OnClick()
	{
		SceneManager.LoadScene (2);
	}
}
