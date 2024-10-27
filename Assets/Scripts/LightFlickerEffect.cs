using UnityEngine;
using System.Collections.Generic;

public class LightFlickerEffect : MonoBehaviour {
	
    private Light thisLight;
    private Material[] theLightMats;
	
    public float minIntensity = 0f;
	
    public float maxIntensity = 1f;
	
	
    public int smoothing = 5;

    Queue<float> smoothQueue;
    float lastSum = 0;

    public void Reset() {
        smoothQueue.Clear();
        lastSum = 0;
    }

    void Start() {
		
	    thisLight = gameObject.GetComponent<Light>();
         smoothQueue = new Queue<float>(smoothing);
    }

    void LateUpdate()
	{
		while (smoothQueue.Count >= smoothing) 
		{
			lastSum -= smoothQueue.Dequeue();
		}
		
		float newVal = Random.Range(minIntensity, maxIntensity);
		smoothQueue.Enqueue(newVal);
		lastSum += newVal;

		thisLight.intensity = lastSum / smoothQueue.Count;
    }

}