using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static bool LogoFaded = false;
	public GameObject fly;
	public GameObject bee;
	public GameObject glowworm;
	public GameObject mosquito;
	public GameObject spider;
	public static int spawnedEnemy = 0;
	public static int lvlCount = 1		;
	private int lifeCount = 10;

	private int count = 0;
	//Background settings 
	public Sprite[] bgSky;
	public Sprite[] bgWater;
	public Sprite[] bgSM;
	public GameObject Sky;
	public GameObject Water;
	public GameObject Sun;
	private SpriteRenderer skyRnd, waterRnd,sunRnd;
	float timeToBeeSpawn = 5f;
	private bool isDay =true;
	public static int spiderCount = 0;

	
	// Use this for initialization
	void Start()
	{
		Sky = GameObject.Find("BGSky");
		Water = GameObject.Find("BGWater");
		Sun = GameObject.Find("BGSM");
		skyRnd = Sky.GetComponent<SpriteRenderer>() ;
		waterRnd = Water.GetComponent<SpriteRenderer>() ;
		sunRnd = Sun.GetComponent<SpriteRenderer>() ;
		count = 0;
		LevelStart(lvlCount);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (count==0 && spawnedEnemy == 0)
		{
			endGame();
		}
		
		if (isDay == true && spiderCount==0)
		{	
			Vector2 tempPos = new Vector2(Random.RandomRange(-4f,4f),11f);
			Instantiate(spider,tempPos,Quaternion.identity);
			spiderCount = 1;
		}

		if (lvlCount == 1 || (7-lvlCount)==1 || (20-lvlCount)==1)
		{
			timeToBeeSpawn -= Time.deltaTime;
			if (timeToBeeSpawn == 0)
			{
				float coordinateX = Random.Range(-4.8f, 4.8f);
				float coordinateY = Random.Range(8f,0f);
				Vector2 tempPosition = new Vector2(coordinateX, coordinateY);
				GameObject enemySpawned = Instantiate(bee, tempPosition, Quaternion.identity);
			}

		}
		
		
	}

	private void SpawnEnemy(GameObject enemy){
		float coordinateX = Random.Range(-4.8f, 4.8f);
		float coordinateY = Random.Range(8f,0f);
		Vector2 tempPosition = new Vector2(coordinateX, coordinateY);
		GameObject enemySpawned = Instantiate(enemy, tempPosition, Quaternion.identity);
		spawnedEnemy += 1;
	}

	private void endGame()
	{
		flyControl.speed = 0;
		mosquitoControl.speed = 0;
		beeControl.speed = 0;
		grigControl.speed = 0;
		SceneManager.LoadScene(2);
	}

	private void LevelStart(int lvlCnt)
	{
		int spawned = 10 + lvlCnt;
		int count = spawned / lvlCnt;
		
		
		if ((lvlCnt % 6) == 0)
		{
			skyRnd.sprite = bgSky[5];
			waterRnd.sprite = bgWater[4];
			sunRnd.sprite = bgSM[1];
			grigControl.speed = 10f;
			isDay = false;
			for (int i = 0; i < 2*spawned; i++)
			{
				SpawnEnemy(glowworm);
			}
			
		}
		else if ((lvlCnt % 5) == 0)
		{
			skyRnd.sprite = bgSky[4];
			waterRnd.sprite = bgWater[3];
			sunRnd.sprite = bgSM[1];
			mosquitoControl.speed = 10f;
			isDay = false;
			for (int i = 0; i < 0.5*spawned; i++)
			{
				SpawnEnemy(mosquito);
			}
			
		}
		else if ((lvlCnt % 4) == 0)
		{	
			skyRnd.sprite = bgSky[3];
			waterRnd.sprite = bgWater[2];
			sunRnd.sprite = bgSM[0];
			mosquitoControl.speed = 10f;
			isDay = true;
			for (int i = 0; i < 0.5*spawned; i++)
			{
				SpawnEnemy(mosquito);
			}
		}
		else if ((lvlCnt % 3) == 0)
		{
			skyRnd.sprite = bgSky[2];
			waterRnd.sprite = bgWater[1];
			sunRnd.sprite = bgSM[0];	
			mosquitoControl.speed = 10f;
			flyControl.speed = 10f;
			isDay = true;
			for (int i = 0; i < 0.5*spawned; i++)
			{
				SpawnEnemy(fly);
			}

			for (int i = 0; i < 0.5*spawned; i++)
			{
				SpawnEnemy(mosquito);
			}
			
		}
		else if ((lvlCnt % 2) == 0)
		{
			skyRnd.sprite = bgSky[1];
			waterRnd.sprite = bgWater[1];
			sunRnd.sprite = bgSM[0];
			flyControl.speed = 10f;
			isDay = true;
			for (int i = 0; i < spawned; i++)
			{
				SpawnEnemy(fly);
			}
			
		}
		else if ((lvlCnt % 1) == 0)
		{
			skyRnd.sprite = bgSky[0];
			waterRnd.sprite = bgWater[0];
			sunRnd.sprite = bgSM[0];
			flyControl.speed = 10f;
			isDay = true;
			for (int i = 0; i < count; i++)
					{
						SpawnEnemy(fly);
					}
				
				
			}
		
	}

	
	
}
