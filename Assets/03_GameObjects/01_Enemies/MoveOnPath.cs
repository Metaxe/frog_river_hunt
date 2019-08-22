using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	public PathPlacer pathToFollow;
	public int CurrentWP = 0;
	public float speed;
	private float reachDistance = 1.0f;
	public string pathName;

	private Vector2 lastPos;
	private Vector2 currentPos;
	
	// Use this for initialization
	void Start ()
	{
		
		lastPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
