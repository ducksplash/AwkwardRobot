using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;


public class CubeTransform : MonoBehaviour
{
	Rigidbody2D qubeRigidBody;
	public static bool QubeFrozen = false;
	private List<Light> qubeLights;
	private List<GameObject> wallLights;
	private string wallLightsTag;
	private GameObject AllMyCubes;
	private float determineFlash;
	
	IEnumerator waiter()
	{
		foreach (Light thisLight in qubeLights)
		{
			thisLight.color = new Color32(0,0,0,200);
			thisLight.intensity = 0;
		}
		//Wait for 4 seconds
		yield return new WaitForSeconds(0.01f);
		
		foreach (Light thisLight in qubeLights)
		{
			thisLight.color = new Color32(255,255,255,200);
			thisLight.intensity = 15;
		}

	}	
	
	
	
	
	IEnumerator waitingWall(string wallLightTag)
	{
		
		wallLights = new List<GameObject>(GameObject.FindGameObjectsWithTag(wallLightTag));
			
		
		
		foreach (GameObject thisWallLight in wallLights)
		{
			thisWallLight.GetComponent<Light>().color = new Color32(0,0,0,200);
			thisWallLight.GetComponent<Light>().intensity = 0;
		}
		//Wait for 4 seconds
		yield return new WaitForSeconds(0.1f);
		
		foreach (GameObject thisWallLight in wallLights)
		{
			thisWallLight.GetComponent<Light>().color = new Color32(255,255,180,150);
			thisWallLight.GetComponent<Light>().intensity = 5;
		}

	}
	
	
	void OnCollisionEnter2D(Collision2D other)
	{ 
	
		
		if (other.transform.name.Contains("meCube"))
		{
			
			
			determineFlash = Random.Range(0,100);
			
			if (determineFlash > 49)
			{
				StartCoroutine(waiter());
			}		
		}
		
	}
		
	void OnTriggerEnter2D(Collider2D other)
	{		
		
		if (other.transform.name.Contains("Left"))
		{

			determineFlash = Random.Range(0,100);
			
			if (determineFlash > 49)
			{
				StartCoroutine(waitingWall("wallLightLeft"));
			}			
		}
		
		if (other.transform.name.Contains("Right"))
		{

			determineFlash = Random.Range(0,100);
			
			if (determineFlash > 49)
			{
				StartCoroutine(waitingWall("wallLightRight"));
			}			
		}	
		
		if (other.transform.name.Contains("Top"))
		{

			determineFlash = Random.Range(0,100);
			
			if (determineFlash > 49)
			{
				StartCoroutine(waitingWall("wallLightTop"));
			}			
		}
		
		
		if (other.transform.name.Contains("Bottom"))
		{

			determineFlash = Random.Range(0,100);
			
			if (determineFlash > 49)
			{
				StartCoroutine(waitingWall("wallLightBottom"));
			}			
		}
	}
	
	
	
	
	
	void Start()
	{
		qubeRigidBody = gameObject.GetComponent<Rigidbody2D>();
		qubeLights = new List<Light>(gameObject.GetComponentsInChildren<Light>());

		
	}
	
	public void rotateCube()
	{
		if (!PlayerReady.PLAYER_IS_READY && qubeRigidBody.bodyType != RigidbodyType2D.Static)
		{
			
		// light me qube
			foreach (Light thisLight in qubeLights)
			{
				thisLight.color = new Color32(0,200,0,200);
			}
			

		new Color(0.5f,0,0,0.7f);
	
		// Rotate me qoooooob
		var x = qubeRigidBody.transform.rotation.x;
		var y = qubeRigidBody.transform.rotation.y;
		var z = qubeRigidBody.transform.rotation.z;
		
		var rotAmount = 90f;

		qubeRigidBody.transform.Rotate(transform.rotation.x,transform.rotation.y,Mathf.Round(rotAmount));

		foreach (Light thisLight in qubeLights)
		{
			thisLight.color = new Color32(255,255,255,200);
		}
		
		}
	}
	
	
	
	public void freezeCube()
	{		
		
		if (!PlayerReady.PLAYER_IS_READY)
		{	

			
			if (qubeRigidBody.bodyType != RigidbodyType2D.Static)
			{
				qubeRigidBody.bodyType = RigidbodyType2D.Static;
				gameObject.GetComponentInChildren<Image>().enabled = true;
				
				
				// light me qube
				foreach (Light thisLight in qubeLights)
				{
				thisLight.color = new Color32(180,230,255,200);
				}
				
			}
			else
			{
				qubeRigidBody.bodyType = RigidbodyType2D.Dynamic;
				gameObject.GetComponentInChildren<Image>().enabled = false;
				
				// light me qube
				foreach (Light thisLight in qubeLights)
				{
					thisLight.color = new Color32(255,255,255,200);
				}
			}			
			
		}
		

	}	
	

	
	public void destroyCube()
	{
		
		if (!PlayerReady.PLAYER_IS_READY)
		{		
		
			gameObject.SetActive(false);
		
		
		}
	
	}

}
