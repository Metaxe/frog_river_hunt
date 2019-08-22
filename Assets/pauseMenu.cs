using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{

	public static bool isPaused = false;

	public static GameObject pauseMenuUI;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void Pause()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		isPaused = true;
	}

	public static void Resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		isPaused = false;
	}
}
