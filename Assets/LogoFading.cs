using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LogoFading : MonoBehaviour {	
	private SpriteRenderer rend;
	public Sprite[] logos;
	
	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer>();
		Color c = rend.material.color;
		c.a = 0f;
		rend.material.color = c;
	}

	public void LoadLevel(int num)
	{
		rend = GetComponent<SpriteRenderer>();
		rend.sprite = logos[num - 1];
	}
	
	IEnumerator FadeOut()
	{
		for (float f = 0.75f; f >= -0.02f; f -= 0.02f)
		{
			Color c = rend.material.color;
			c.a = f;
			rend.material.color = c;
			yield return new WaitForSeconds(0.2f);
		}

		GameManager.LogoFaded = true;
	}
	
	 public void StartFadingOut()
	{
		StartCoroutine(FadeOut());
	}

}
