using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lilyControl : MonoBehaviour {

	private bool isCathced = false;
	public Path path;
	public PathCreator pCreator;
	public float spacing = .1f;
	public float resolution = 1;
	public int CurrentWP = 0;
	public static float speed = 5f;
	private float reachDistance = 1.0f;
	public string pathName;
	private Vector2 lastPos;
	private Vector2 currentPos;
	private Vector2[] points;
	
	
	
	
	
	
	private void Start()
	{
		points = pCreator.path.CalculateEvenlySpacedPoints(spacing, resolution);
		for (int i = 0; i < points.Length; i++)
		{
			points[i].x += Random.RandomRange(0.05f, 0.1f);
			points[i].y += Random.RandomRange(0.05f, 0.1f);
		}
		
		

		CurrentWP = Random.RandomRange(0, points.Length-10);

	}

	private void Update()
	{
		if (CurrentWP >= points.Length)
		{
			CurrentWP = 0;
		}
		
		float distance = Vector2.Distance(points[CurrentWP], transform.position);
		transform.position = Vector2.MoveTowards(transform.position, points[CurrentWP], Time.deltaTime * speed);

		if (distance <= reachDistance)
		{
			CurrentWP++;
		}

		
	}


	
}

