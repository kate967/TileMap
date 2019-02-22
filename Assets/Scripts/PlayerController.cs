using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float speed;
    public float jumpforce;

	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

	void Update ()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
        Debug.Log("Quitting");
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
            }
        }
    }
}
