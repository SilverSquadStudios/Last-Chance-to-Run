using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public ScoreManager Score;

	public GameManager TheGameManager;

	public float Speed;
	private float SpeedStore;

	public float Speedmultiplier;
	public float SpeedIncreaseMilestone;
	private float MilestoneIncreaseStore;

	private float SpeedMilestoneCount;
	private float MilestoneCountStore;

	public float Jump;
	private bool DoubleJump;

	private Rigidbody2D myRB;

	private bool StopJumping;
	public bool ground;
	public LayerMask recognizingground;
	public Transform groundCheck;
	public float groundCheckRadius;

	public float JumpTime;
	private float JumpTimeCounter;

	public bool SlowDownPowerUp;
	private float StoredSpeed;



	void Start ()
	{
		myRB = GetComponent<Rigidbody2D> ();
		JumpTimeCounter = JumpTime;
		SpeedStore = Speed;
		MilestoneCountStore = SpeedMilestoneCount;
		MilestoneIncreaseStore = SpeedIncreaseMilestone;
		StopJumping = true;
		DoubleJump = true;
		SlowDownPowerUp = false;
		StoredSpeed = Speed;
	}
	

	void Update ()
	{
		ground = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,recognizingground);

		if (Input.touchCount == 1)
		{
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                if (ground)
                {
                    myRB.velocity = new Vector2(myRB.velocity.x, Jump);
                    StopJumping = false;

                }
                if (!ground && DoubleJump)
                {
                    myRB.velocity = new Vector2(myRB.velocity.x, Jump);
                    JumpTimeCounter = JumpTime;
                    StopJumping = false;
                    DoubleJump = false;
                }
            }
		}
		if (Input.touchCount == 1 && !StopJumping)
		{
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                if (JumpTimeCounter > 0)
                {
                    myRB.velocity = new Vector2(myRB.velocity.x, Jump);
                    JumpTimeCounter -= Time.deltaTime;
                }
            }
		}
		if (Input.touchCount == 1)
		{
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                JumpTimeCounter = 0;
                StopJumping = true;
            }
		}
		if (ground) 
		{
			JumpTimeCounter = JumpTime;
			DoubleJump = true;
		}

		if (!SlowDownPowerUp)
		{
			Speed = StoredSpeed;
			myRB.velocity = new Vector2 (Speed, myRB.velocity.y);
			if (transform.position.x > SpeedMilestoneCount)
			{
				SpeedMilestoneCount = SpeedIncreaseMilestone;
				Speed = Speed * Speedmultiplier;
				SpeedIncreaseMilestone += (SpeedIncreaseMilestone * Speedmultiplier) / 3;
			}
			StoredSpeed = Speed;
		}
		if (SlowDownPowerUp) 
		{
			myRB.velocity = new Vector2 (Speed/2, myRB.velocity.y);
		}

	}
		
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "KillBox")
		{
			TheGameManager.RestartGame();
		}
	}

	public void ResetGame()
	{
		TheGameManager.RestartGame();
	}

	public void ResetSpeed()
	{
		Speed = SpeedStore;
		StoredSpeed = SpeedStore;
		SpeedMilestoneCount=MilestoneCountStore;
		SpeedIncreaseMilestone = MilestoneIncreaseStore;
	}
}
