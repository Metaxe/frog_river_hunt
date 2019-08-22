using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement: MonoBehaviour {
	
	private Vector2 currPos,movVec;
	private float speed = 0.1f;
	private string exitTrigger;
	private bool exitTriggerSet = false;
	
	// Use this for initialization
	void Start ()
	{
		currPos = this.transform.position;
		StartMoving();
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(movVec*speed*Time.deltaTime);
	}
	//Setting up a moving Vector 
	private void StartMoving()
	{
		if (currPos.x == 12)
		{
			movVec = new Vector3(-13f, currPos.y,0);
			
		}
		else
		{
			movVec = new Vector3(13.0f, currPos.y,0);
		}
	}
	//Checking for collision to spawn new wave or destroy this.
	private void OnTriggerEnter2D(Collider2D name)
	{
		if (exitTriggerSet == false)
		{
			if (name.gameObject.name == "cloudBorder_left" )
			{

				exitTrigger = "cloudBorder_right";
				
			}
			else if(name.gameObject.name == "cloudBorder_right")
			{
				exitTrigger = "cloudBorder_left";
				
			}

			exitTriggerSet = true;
		}
		if (name.gameObject.name == exitTrigger )
		{
			CloudControl.numCloud -= 1;
		}
		
		
	}
	
	private void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.name == exitTrigger)
		{
			Destroy(this.gameObject);
			
		}
		
	}




	
}
