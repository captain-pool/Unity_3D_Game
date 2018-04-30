using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run : MonoBehaviour {
    // Use this for initialization
    public Rigidbody rb;
	void Start () {
		
	}
	void exitGame()
    {
        Debug.Log("In Exit");
    }
	// Update is called once per frame
	void Update () {
        if (rb.transform.position.y < -2)
            exitGame();
	}
    private bool isGrounded = false;
    private int power=100,score=0;
    private void reducePower(float impactForce)
    {
        if (power <= 0)
        {
            exitGame();
            return;
        }
        if (impactForce > 46)
            power = 0;
        else
            power -= (int)(impactForce / 46) * 100;

    }
    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(0, -100));
        if (isGrounded)
            rb.velocity = new Vector3(0, 0, 12);
        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
            rb.velocity= new Vector3(-3, 0, 12);
        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
            rb.velocity= new Vector3(3, 0, 12);
        score += 1;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name=="floor")
            isGrounded = true;
        if (collision.transform.name.Contains("enemy"))
            reducePower(Mathf.Abs(50-collision.impulse.z));
        //print(collision.impulse.z);
    }
}
