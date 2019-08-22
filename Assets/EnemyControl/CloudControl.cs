using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudControl : MonoBehaviour {
// Update is called once per frame
	public GameObject[] cloudList;
	public static int numCloud = 0;
	public static bool isSpawned = false;
	
	// Use this for initialization
	void Start ()
	{
		SpawnClouds();
	}
		
		
	// Update is called once per frame
	void Update () {
		if (numCloud < 3)
		{
			isSpawned = false;
		}
		if (isSpawned == false)
		{
			SpawnClouds();
		}
		
	}


	private void SpawnClouds()
	{
		int i = Random.RandomRange(0, 9);
		float coordinateX = 12f;
		if (i > 5)
		{
			coordinateX = -12f;
		}
		else
		{
			coordinateX = 12f;
		}

		float coordinateY = Random.RandomRange(7f,3f);

		float coordinateX_1 = coordinateX;
		float coordinateY_1 = coordinateY;
		float coordinateX_2 = coordinateX_1 + 24f;
		
		if (coordinateX == -12f)
		{
			coordinateX_2 = coordinateX_1 + 24f;
		}

		else
		{
			coordinateX_2 = coordinateX_1 - 24f;
		}

		float coordinateY_2 = coordinateY_1 - 2f;

		float coordinateY_3 = coordinateY_1 + 2f;

		Vector2 tempPosition_1 = new Vector2(coordinateX_1, coordinateY_1);
		Vector2 tempPosition_2 = new Vector2(coordinateX_2, coordinateY_2);
		Vector2 tempPosition_3 = new Vector2(coordinateX_1, coordinateY_3);
		Instantiate(cloudList[0],tempPosition_1,Quaternion.identity);
		Instantiate(cloudList[1], tempPosition_2, Quaternion.identity);
		Instantiate(cloudList[2], tempPosition_3, Quaternion.identity);
		isSpawned = true;
		numCloud += 3;
	}
}
