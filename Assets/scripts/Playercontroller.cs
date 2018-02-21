using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Playercontroller : MonoBehaviour {
    private Rigidbody rb;
    public float Speed;
    public Text CountText;
    public Text GameOver;
    private int score=0;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetCountText();
    }
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.acceleration.x;
        float moveVertical = Input.acceleration.y;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f , moveVertical);
        rb.AddForce(movement* Speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            score++;
            SetCountText();
            if (CountText.text == "Score = 13")
            {
                CountText.text = "";
                GameOver.text = "GAME OVER";
            }
        }
    }
    
    void SetCountText()
    {
        CountText.text = "Score = " + score.ToString();
    }
}