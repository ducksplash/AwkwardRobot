using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


[RequireComponent(typeof(UnityEngine.UI.AspectRatioFitter))]


public class PlayerController : MonoBehaviour,IDragHandler, IPointerUpHandler, IPointerDownHandler
{
	public RectTransform Background;
    public RectTransform Knob;
    Rigidbody2D rb;

    private float speed = 0f;
    public float jumpForce;
	
	
    public GameObject thePlayer;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    public float rememberGroundedFor;
    float lastTimeGrounded;
	
    Collider2D thePlayerBoxCollider;

    private Image jsContainer;
    private Image joystick;
    
    public Vector3 InputDirection;

	private float joyX;
	private float joyY;
	
	public Animator playerAnimator;
	
	
	
    void Start()
    {
        rb = thePlayer.GetComponent<Rigidbody2D>();
        thePlayerBoxCollider = thePlayer.GetComponent<BoxCollider2D>();
        jsContainer = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>(); 
		InputDirection = Vector3.zero;

    }





    public void OnDrag(PointerEventData ped)
	{
        Vector2 position = Vector2.zero;
        
        RectTransformUtility.ScreenPointToLocalPointInRectangle
                (jsContainer.rectTransform, 
                ped.position,
                ped.pressEventCamera,
                out position);
            
            position.x = (position.x/jsContainer.rectTransform.sizeDelta.x);
            position.y = (position.y/jsContainer.rectTransform.sizeDelta.y);
            
            float x = (jsContainer.rectTransform.pivot.x == 1f) ? position.x *2 + 1 : position.x *2 - 1;
            float y = (jsContainer.rectTransform.pivot.y == 1f) ? position.y *2 + 1 : position.y *2 - 1;
            
			joyX = x;
			joyY = y;
			
			
            InputDirection = new Vector3 (x,y,0);
            InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;
            
            joystick.rectTransform.anchoredPosition = new Vector3 (InputDirection.x * (jsContainer.rectTransform.sizeDelta.x/3)
                                                                   ,InputDirection.y * (jsContainer.rectTransform.sizeDelta.y)/3);
            
    }
    
    public void OnPointerDown(PointerEventData ped){
        
        OnDrag(ped);
    }
    
    public void OnPointerUp(PointerEventData ped){
        
        InputDirection = Vector3.zero;
		joyX = 0.0f;
		joyY = 0.0f;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
			
		
    }






    void FixedUpdate()
    {


    }
	
	
	
	void Update()
	{
		speed = PlayerStats.PLAYER_SELECTEDSPEED;
		
		fluffPlayer();
		Move();
		
	    CheckIfGrounded();	
		if (Input.GetButtonDown("Jump"))
		{
			Jump();
		}
		
		
	}
	
	void fluffPlayer()
	{
		
		if (PlayerReady.PLAYER_IS_READY)
		{
			
			thePlayerBoxCollider.enabled = true;
			rb.bodyType = RigidbodyType2D.Dynamic;
			
		}
		else
		{	
			thePlayerBoxCollider.enabled = false;
			rb.bodyType = RigidbodyType2D.Static;
		}
		
	}
	


    void Move()
	{
		float moveBy = 0f;
		
		if (joyX == 0.0f)
		{
			moveBy = Input.GetAxisRaw("Horizontal");
		}
		else
		{	
			moveBy = joyX / 8;	
		}
		
			
		
		if (PlayerReady.PLAYER_IS_READY)
		{
			rb.velocity = new Vector2((moveBy * speed), rb.velocity.y);		
			
			
			
			
			
			if (rb.velocity.x != 0)
			{
				playerAnimator.SetTrigger("playerWalk");
			}
			else
			{
				playerAnimator.SetTrigger("playerIdle");
			}
			

			
		Vector3 thisSpriteScale = thePlayer.GetComponent<RectTransform>().transform.localScale;
        thisSpriteScale.x = Mathf.Sign(joyX - thePlayer.transform.position.x);

							
				if (moveBy < 0)
				{
					thisSpriteScale.x = thisSpriteScale.x;
				}
				
				else if (moveBy > 0) 
				{
					thisSpriteScale.x = -thisSpriteScale.x;
				}			
				else
				{
					thisSpriteScale.x = 1f;
				}				
				thePlayer.transform.localScale = thisSpriteScale;
		}
    }

    public void Jump()
	{	
	
		
		//if (PlayerReady.PLAYER_IS_READY)
		//{			
			if (isGrounded)
			{
				rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			}
		//}
    }


    void CheckIfGrounded()
	{
		
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if (colliders != null)
		{
            isGrounded = true;
        }
		else
		{
            if (isGrounded)
			{
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }
    }    
	
	
}
