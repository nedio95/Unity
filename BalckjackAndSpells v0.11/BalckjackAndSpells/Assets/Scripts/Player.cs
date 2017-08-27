using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {

    public int PlayerIndex;

	public float SpeedFactor2 = 1.0f;
    public float HorDirection = 0f;
    float SpeedFactor = 1.0f;
	float Speed = 5f;


	float max_Jump = 0.1f;
	float currentJump = 0f;
	float jumpTimer = 1f;

	bool canJump = true;
    bool facingLeft = false;

    int PlayerHealth = 3;
    bool IsInvincible = false;
    public float InvincibleTime = 0.1f;

    public float jumpGravity = -5;
    public float fallDownGrav = 1f;

    public float JoystickSensitivity;

    public GameObject LevelResetScreen;

    public GameObject FireBall;
    private float timeToFire = 0;
    public float fireRate = 1;
    Transform firePoint;

    //SpriteRenderer PlayerSprite;


	enum KEYS{
		LEFT = 0,
		RIGHT ,
		UP,
		DOWN,
		JUMP,
		SPELL1,
		SPELL2


	}

	public KeyCode[] InputKey;





	// Use this for initialization
	void Awake () {
        //PlayerSprite = GetComponent<SpriteRenderer>();

        firePoint = transform.FindChild("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("FirePoint NOT found!");
        }
    }
	
	// Update is called once per frame
	void Update () {

        //		CONTROLLER SETUP

        float x = Input.GetAxis ("J" + PlayerIndex + "Hor");
        float z = Input.GetAxis("J" + PlayerIndex + "Ver");
        float r = Input.GetAxis("J" + PlayerIndex + "HorR");

        //=========
        // MOVEMENT

        float directionSpeed = 0f;

        // Horizontal
        if (x <= -JoystickSensitivity || Input.GetKey(InputKey[0])) // left
        {
            
            if (HorDirection != -1f)
            {
                HorDirection = -1f;
                this.gameObject.transform.Rotate(new Vector3(0f, 180f, 0f));
            }
            directionSpeed = -1f;

            //facingLeft = true;
        }

        else if (x >= JoystickSensitivity || Input.GetKey(InputKey[1])) // right
        {
            if (HorDirection != 1f)
            {
                HorDirection = 1f;
                this.gameObject.transform.Rotate(new Vector3(0f, 180f, 0f));
            }
            directionSpeed = 1f;
            //facingLeft = false;
        }

        //if (facingLeft)
        //{
        //    PlayerSprite.flipX = true;
        //}
        //else
        //{
        //    PlayerSprite.flipX = false;
        //}

		Vector3 pos = new Vector3(0f, 0f, 0f);
		pos.x += Speed * SpeedFactor2 * SpeedFactor * Time.deltaTime * directionSpeed;

        // Jumping

		if ((Input.GetKeyDown("joystick " + PlayerIndex + " button 0" ) || (Input.GetKeyDown (InputKey [4]))) && (canJump)) 
		{
            Debug.Log("Jump Button");
			if(currentJump == 0f)
				{
                    Debug.Log(currentJump);
					canJump = false;
					currentJump = max_Jump;
					gameObject.GetComponent<Rigidbody2D>().gravityScale = jumpGravity;
					
				}
		}

		if (currentJump > 0f) {
			currentJump -= Time.deltaTime;
		} else {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = fallDownGrav;
            currentJump = 0f;
		}

		transform.position += pos; 
	
        // Level Reset if player dead
        if (PlayerHealth == 0)
        {
            
            LevelResetScreen.SetActive(true);
            Time.timeScale = 0;
            Destroy(gameObject, 0f);

        }

        // Shoot
        //joystick 1 button 1
        if ((Input.GetKeyDown("joystick " + PlayerIndex + " button 1") ||Input.GetKey(InputKey[5])) && (Time.time > timeToFire))
        {
            timeToFire = Time.time + 1 / fireRate;
            Shoot();
        }
    }

	void OnCollisionEnter2D(Collision2D col)
	{
		if (currentJump > 0f)
			return;
		float vertPos = gameObject.transform.position.y;
		float colPos = col.transform.position.y;

		if (vertPos > colPos)
			canJump = true;
        if (col.gameObject.tag == "Damaging") // if it isnt another player
        {
            if (IsInvincible)
            {
                return;
            }
            IsInvincible = true;

            PlayerHealth--;

            OnHitColourChange();

        }
        if (col.gameObject.tag == "KillZone") // Kill player
        {

            PlayerHealth = 0;
            OnHitColourChange();
            CancelInvoke();
        }
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Stamper")
        {

            if (IsInvincible)
            {
                return;
            }
            IsInvincible = true;

            PlayerHealth--;
            OnHitColourChange();
          }
    }

    void Shoot()
    {

        Vector3 firePointPosition = new Vector3(firePoint.position.x, firePoint.position.y, 0);

        GameObject obj = Instantiate(FireBall, firePointPosition, firePoint.rotation) as GameObject;


    }

    void OnHitColourChange()
    {
        SpriteRenderer t_sprite = gameObject.GetComponent<SpriteRenderer>();
        Color colour = new Color(1f, 0.1f, 0.1f, 1f);
        t_sprite.color = colour;
        Invoke("OnHitColourChange2", 0.1f);

    }

    void OnHitColourChange2()
    {
        SpriteRenderer t_sprite = gameObject.GetComponent<SpriteRenderer>();
        Color colour = new Color(1f, 1f, 1f, 1f);
        t_sprite.color = colour;
        IsInvincible = false;
    }

}
