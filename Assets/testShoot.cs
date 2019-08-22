using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testShoot : MonoBehaviour
{
	[SerializeField]
	float moveSpeed = 10f;

	private float maxDistance = 10f;

	Rigidbody2D rb;
	private LineRenderer line;

	Touch touch;
	Vector3 touchPosition, whereToMove,startPos, secondPos;
	bool isMoving = false;

	float previousDistanceToTouchPos, currentDistanceToTouchPos;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		line = GetComponent<LineRenderer>();
		startPos = transform.position;
		Vector3 firstPos = new Vector3(startPos.x,startPos.y,startPos.z+10f);
		line.SetPosition(0,firstPos);
		
	}
	
	void Update () {
		secondPos = new Vector3(transform.position.x,transform.position.y,transform.position.z+10f);
		line.SetPosition(1,secondPos);
		
		if (isMoving)
			currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;
		
		if (Input.touchCount > 0) {
			touch = Input.GetTouch (0);

			if (touch.phase == TouchPhase.Began) {
				previousDistanceToTouchPos = 0;
				currentDistanceToTouchPos = 0;
				isMoving = true;
				touchPosition = Camera.main.ScreenToWorldPoint (touch.position);
				touchPosition.z = 0;
				whereToMove = (touchPosition - transform.position).normalized;
				rb.velocity = new Vector2 (whereToMove.x * moveSpeed, whereToMove.y * moveSpeed);
			}
		}
		
		
		
		if (currentDistanceToTouchPos > previousDistanceToTouchPos) {
			isMoving = false;
			rb.velocity = Vector2.zero;
		}

		if (isMoving)
			previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;


		if ((transform.position - startPos).magnitude > maxDistance && isMoving==false)
		{
			transform.position = startPos;
		}
		
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		transform.position = startPos;
	}
}
