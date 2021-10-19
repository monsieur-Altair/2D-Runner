using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    bool isOnGround;//, isDie;
    public float force = 10f;
    public GameObject gameManager;
    private int hpScore;
    GameObject score;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("HPTag");
        hpScore = 3;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isOnGround = true;
        //isDie = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetKey("space"))
        {
            Vector2 direction = new Vector2(0, force) * Time.deltaTime;
            rb.AddForce(direction);
            if (isOnGround)
            {
                animator.SetBool("isGround", false);
                isOnGround = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "EarthTag" && !isOnGround)
        {
            isOnGround = true;
            animator.SetBool("isGround", true);
        }
        if (collision.collider.tag == "ObstacleTag")
        {
            //isDie = true;

            hpScore--;
            score.GetComponent<HPscore>().Score -= 1;
            if (hpScore == 0)
            {
                gameManager.GetComponent<GameManager>().SetGMState(GameManager.GameManagerState.GAMEOVER);
                animator.SetBool("isDie", true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag=="healTag")
        {
            hpScore++;
            score.GetComponent<HPscore>().Score += 1;
        }
    }
}
