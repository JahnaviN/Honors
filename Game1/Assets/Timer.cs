using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public Text timerLabel;

    private float time = 30;

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            SceneManager.LoadScene(1);
        }
        time -= Time.deltaTime;

        var seconds = time % 60;
        var fraction = (time * 100) % 100;

        timerLabel.text = string.Format("{0:00} : {1:000}", seconds, fraction);
    }
}
