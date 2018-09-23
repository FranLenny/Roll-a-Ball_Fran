using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;

    private Rigidbody rb;
    private int count;
    private int score;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        SetCountText ();
        SetScoreText ();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetKey("escape"))
            Application.Quit();

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

   private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            SetAllText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            // count = count + 1;
            score = score - 1; 
            SetAllText();
        }
        if (count == 12)
        {
            transform.position = new Vector3(37.5f, 22f, -8.7f);
        }
    }

    void SetCountText ()
    {
        countText.text = "count: " + count.ToString();   
    }
    void SetScoreText ()
    {
        scoreText.text = "score: " + count.ToString();
    }
    void SetAllText ()
    {
        scoreText.text = "score: " + score.ToString();
        countText.text = "count: " + count.ToString();
        if (count >= 24)
        {
            winText.text = "You finished with a score of: " + score.ToString();
        }
    }
}