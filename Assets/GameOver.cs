using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOver : MonoBehaviour {

    // Use this for initialization
    public TextMeshProUGUI score;
    public void Start()
    {
        score.text = Score.score.ToString();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
