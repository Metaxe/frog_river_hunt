﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playButton : MonoBehaviour {
	
	private void OnMouseDown()
	{
		SceneManager.LoadScene(1);
	}
}
