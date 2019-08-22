using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitButtonScript : MonoBehaviour {
	
	private void OnMouseDown()
	{
		SceneManager.LoadScene(0);
	}
}
