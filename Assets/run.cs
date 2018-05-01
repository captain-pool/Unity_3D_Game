using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class run : MonoBehaviour {
    // Use this for initialization
    public Rigidbody rb;
    public TextMeshProUGUI sliderText;
    public Slider slider;
	void Start () {
	}
	void exitGame()
    {
        Score.score = score;
        SceneManager.LoadScene("GameOver");

    }
	// Update is called once per frame
	void Update () {
        if (rb.transform.position.y < -0.2)
            exitGame();
	}
    private bool isGrounded = false;
    private int score = 0;
    double power=100;
    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(0, -300));
        if (isGrounded)
            rb.velocity = new Vector3(0, 0, 12);
        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
            rb.velocity= new Vector3(-2, 0, 12);
        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
            rb.velocity= new Vector3(2, 0, 12);
#if UNITY_IPHONE || UNITY_ANDROID
        Rect left, right;
        if(Input.touchCount>0)
        {
            {
                right = new Rect(new Vector2(0, 0), new Vector2(Screen.width / 2, Screen.height));
                left= new Rect(new Vector2(Screen.width/2,0), new Vector2(Screen.width / 2, Screen.height));
            }
            if (left.Contains(Input.GetTouch(0).position))
            {
                rb.velocity = new Vector3(3, 0, 12);
            }else
                if(right.Contains(Input.GetTouch(0).position))
            {
                rb.velocity = new Vector3(-3, 0, 12);
            }
        }
#endif
        if(isGrounded && !crash)
        score += 1;
        if (crash)
        {
            power -= 0.4;
        }
        if ((int)power <= 0)
            exitGame();
        slider.value = (int)power;
        sliderText.text = ((int)score).ToString();
    }
    private bool crash = false;
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name=="floor")
            isGrounded = true;
        if (collision.transform.name.Contains("enemy"))
            crash = true;
        //print(collision.impulse.z);
    }
    public void OnCollisionExit(Collision collision)
    {
        
        if (collision.transform.name.Contains("enemy"))
        {
            crash = false;
        }
    }
}
public class Score
{
    private static int s=0;
    public static int score { get { return s; } set { s = value; } }
}