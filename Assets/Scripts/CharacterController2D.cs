using UnityEngine;
using UnityEngine.Events;

// Source
// https://github.com/Brackeys/2D-Character-Controller

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.

    public int CharacterLives = 3;

    public float knockBackCount;
    public float knockBackLength;
    public bool knockBackFromRight;
    [SerializeField] private float knockBack;

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	public bool m_Grounded;            // Whether or not the player is grounded.
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;
	private bool isColliding = false;

    public float invulnerabilityCount = 0f;

	//References
	private gameMaster gm;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;
		isColliding = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}

        // Deal with slopes
        NormalizeSlope();

        invulnerabilityCount -= Time.deltaTime;
    }


	public void Move(float move, bool jump)
	{
		//only control the player if grounded or airControl is turned on
		if ((m_Grounded || m_AirControl) && knockBackCount <= 0)
		{
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
        else
        {
            // If player was knocked back
            if (knockBackFromRight)
            {
                m_Rigidbody2D.velocity = new Vector2(-knockBack, knockBack);
            }
            else
            {
                m_Rigidbody2D.velocity = new Vector2(knockBack, knockBack);
            }
            knockBackCount -= Time.deltaTime;
        }
		// If the player should jump...
		if (m_Grounded && jump)
		{
            // Play jump sound
            SoundManagerScript.PlaySound("Jump");

            // Add a vertical force to the player.
            m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}
        
    }

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

        // Rotate 180 on Y axis
        transform.Rotate(0f, 180f, 0f);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("WhiteBloodCell"))
		{
			if (isColliding)
			{
				return;
			}

            SoundManagerScript.PlaySound("PickUpWBC");
            Destroy(col.gameObject);
			gm.wbcCount += 1;
			isColliding = true;
		}
        if (col.CompareTag("Platelet"))
        {
            if (isColliding)
            {
                return;
            }

            SoundManagerScript.PlaySound("PickUpWBC");
            Destroy(col.gameObject);
            gm.plateletCount += 1;
            isColliding = true;
        }

        if (col.CompareTag("OxygenInfusion"))
        {
            if (isColliding)
            {
                return;
            }

            SoundManagerScript.PlaySound("PickUpWBC");
            Destroy(col.gameObject);
            gm.countDown += 2f;
            isColliding = true;
        }

        if (col.CompareTag("ScorePickup"))
        {
            if (isColliding)
            {
                return;
            }

            SoundManagerScript.PlaySound("PickUpWBC");
            Destroy(col.gameObject);
            GameObject.Find("Score").GetComponent<ScoreTracker>().totalScore += 1;
            gm.levelScore += 1;

            Debug.Log(GameObject.Find("Score").GetComponent<ScoreTracker>().totalScore);
            isColliding = true;
        }
    }

    void NormalizeSlope()
    {
        // Improves movement on slopes.
        // Source: https://www.youtube.com/watch?v=xMhgxUFKakQ

        // Attempt vertical normalization
        if (m_Grounded)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 1f, m_WhatIsGround);

            if (hit.collider != null && Mathf.Abs(hit.normal.x) > 0.1f)
            {
                // Apply the opposite force against the slope force
                m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x - (hit.normal.x * 0.25f), m_Rigidbody2D.velocity.y / 2);

                //Move Player up or down to compensate for the slope below them
                Vector3 pos = transform.position;
                pos.y += -hit.normal.x * Mathf.Abs(m_Rigidbody2D.velocity.x) * Time.deltaTime * (m_Rigidbody2D.velocity.x - hit.normal.x > 0 ? 1 : -1);
                transform.position = pos;
            }
        }
    }
}
