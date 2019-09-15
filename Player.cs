using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    public float jumpForce;
    public bool platform;
    private bool stopJumping;
    private bool canDoubleJump;
    public LayerMask layerMask;
    public Transform groundCheck;
    public float radiusCheck;
    public float jumpTime;
    public GameManager gameManager;

    private float jumpTimeCounter;
    private Rigidbody2D rb2d;
    //private Collider2D cldr2d;
    private Animator animator;
    private float speedMilestoneCount;
    private float speedStore;
    private float speedMilestoneCountStore;
    private float speedIncreaseMilestoneStore;
    public GameObject player;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //cldr2d = GetComponent<Collider2D>();
        jumpTimeCounter = jumpTime;
        speedMilestoneCount = speedIncreaseMilestone;
        speedStore = speed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;
        stopJumping = true;
        player = GameObject.FindGameObjectWithTag("Player");
        int playerNumber = PlayerPrefs.GetInt("CharacterSelected");
        Transform[] trs = player.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in trs)
        {
            if (t.name == "Player" + playerNumber)
            {
                GameObject objSel = t.gameObject;
                objSel.SetActive(true);
                animator = objSel.GetComponent<Animator>();
            }
        }
    }

    void Update()
    {
        //platform = Physics2D.IsTouchingLayers(cldr2d, layerMask);
        platform = Physics2D.OverlapCircle(groundCheck.position, radiusCheck, layerMask);

        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone += speedIncreaseMilestone;
            speed += speedMultiplier;
        }

        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (platform)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
                stopJumping = false;
            }

            if (!platform && canDoubleJump)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
                jumpTimeCounter = jumpTime;
                stopJumping = false;
                canDoubleJump = false;
            }
        }

        if((Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !stopJumping)
        {
            if(jumpTimeCounter > 0)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }

        }

        if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
            stopJumping = true;
        }

        if (platform)
        {
            jumpTimeCounter = jumpTime;
            canDoubleJump = true;
        }

        animator.SetFloat("Speed", rb2d.velocity.x);
        animator.SetBool("Platform", platform);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "KillBox")
        {
            speed = speedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
            gameManager.RestartGame();
        }
    }
}