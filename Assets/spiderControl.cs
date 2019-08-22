using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class spiderControl : MonoBehaviour
{
	private Vector3 startPos,targetPos;

	public float speed = 1f;
	private LineRenderer line;

	// Use this for initialization
	void Start ()
	{
		startPos = transform.position;
		targetPos = new Vector3(startPos.x, startPos.y - 10f);
		line = GetComponent<LineRenderer>();
		line.SetPosition(0,startPos);

	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position == targetPos)
		{
			targetPos = startPos;
		}
		
		transform.position = Vector2.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
		line.SetPosition(1,transform.position);
		
	}

	private void OnTriggerEnter2D(Collider2D name)
	{
		if (name.name == "Tongue")
		{
			Destroy(this.gameObject);
			GameManager.spiderCount = 0;
		}
	}
}
