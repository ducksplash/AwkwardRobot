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
	

	
	void FixedUpdate()
	{
		
			
		Vector3 controlInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
			
			if (!PlayerReady.PLAYER_IS_READY && qubeRigidBody.bodyType != RigidbodyType2D.Static)
			{


				if (SystemInfo.deviceType != DeviceType.Handheld)
				{				
				qubeRigidBody.MovePosition(transform.position + controlInput * Time.deltaTime * (speed * 100));

				//gameObject.transform.position = new Vector2 (transform.position.x + (h * speed), 
				//transform.position.y + (v * speed));
				

				}
				else
				{
				Vector3 dir = Vector3.zero;					
					
				dir.y = Input.acceleration.y;
				dir.x = Input.acceleration.x;

				// clamp acceleration vector to unit sphere
				if (dir.sqrMagnitude > 1)
					dir.Normalize();

				// Make it move 10 meters per second instead of 10 meters per frame...
				dir *= Time.deltaTime;




	


				// Move object
				//gameObject.transform.Translate(dir * 100);
				
				qubeRigidBody.MovePosition(transform.position + dir * Time.deltaTime * (10 * 1000));

				
				}

			}		
			else
			{
				
				gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
				
			}
		
	}
	
	




}