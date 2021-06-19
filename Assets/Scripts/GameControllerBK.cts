using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	
	public float speed = 0.1f;	
	private GameObject theseQubes;
	Rigidbody2D qubeRigidBody;
	
	void Start()
	{
		
		theseQubes = gameObject;
		qubeRigidBody = theseQubes.GetComponent<Rigidbody2D>();
		
		

		
	}
	
	
	private void bump(GameObject thisBlock)
	{

		   //thisBlock.transform.position = new Vector2 (transform.position.x + (-0.2f * speed), 
		   //transform.position.y + (-0.2f * speed));
		
	}

	
	private void OnCollisionEnter2D(Collision2D collision)
    {
        //inContactWithWall = true;
		//bump(gameObject);
    }

	
	void FixedUpdate()
	{
		
			
		Vector3 controlInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
			
			if (!PlayerReady.PLAYER_IS_READY)
			{




				if (SystemInfo.deviceType != DeviceType.Handheld)
				{				
				qubeRigidBody.MovePosition(transform.position + controlInput * Time.deltaTime * (speed * 100));

				//gameObject.transform.position = new Vector2 (transform.position.x + (h * speed), 
				//transform.position.y + (v * speed));
				
				Vector3 dir = Vector3.zero;
				}
				else
				{
					
				
				Vector3 tiltInput = new Vector3(Input.acceleration.x, Input.acceleration.y, 0);

				// clamp acceleration vector to unit sphere
				//if (tiltInput.sqrMagnitude > 1)
				//	tiltInput.Normalize();

				// Make it move 10 meters per second instead of 10 meters per frame...
				tiltInput *= Time.deltaTime;

				// Move object
				qubeRigidBody.MovePosition(transform.position + controlInput * Time.deltaTime * (speed * 100));					
				}

			}		
			else
			{
				
				gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
				
			}
		
	}
	
	




}