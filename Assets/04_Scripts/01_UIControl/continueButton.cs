using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class continueButtonScript : MonoBehaviour {
	
	private void OnMouseDown()
	{
		GameManager.lvlCount += 1;
		SceneManager.LoadScene(1);
	}
}
