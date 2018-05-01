using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class renderScene : MonoBehaviour {

    // Use this for initialization
    
    public void navigateScene (string scene) {
        if(scene=="e")
        {
            Application.Quit();
            return;
        }
        SceneManager.LoadScene(scene);
	}
}
