using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    private int score;
    private int lives;
    private int count;
    private bool facingRight = true;

    public float speed;
    public float jumpforce;
    public Text scoreText;
    public Text winText;
    public Text livesText;
    public Text loseText;
    public GameObject Player;

    Animator anim;

    public AudioClip backgroundMusic;
    public AudioClip winMusic;
    public AudioSource musicSource;

    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();

        count = 0;
        score = 0;
        lives = 3;
        setScoreText();
        winText.text = "";
        loseText.text = "";

        anim = GetComponent<Animator>(); 

        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetInteger("State", 1);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetInteger("State", 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetInteger("State", 1);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetInteger("State", 0);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);

        if (count == 4)
        {
            transform.position = new Vector2(-31.09f, -3.18f);
            count = count + 1;
        }
        if (facingRight == false && moveHorizontal > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveHorizontal < 0)
        {
            Flip();
        }

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
                anim.SetInteger("State", 2);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            count = count + 1;
            setScoreText();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            setScoreText();
        }
    }

    void setScoreText()
    {
        scoreText.text = "Score: " + score.ToString();

        if (score >= 8)
        {
            winText.text = "You Win!";
            musicSource.clip = winMusic;
            musicSource.Play();
            musicSource.loop = false;
        }

        livesText.text = "Lives: " + lives.ToString();

        if (lives == 0)
        {
            loseText.text = "You Lose.";
            GameObject.Destroy(Player);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }
}
