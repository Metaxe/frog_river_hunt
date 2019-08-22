﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPlacer : MonoBehaviour {

    public float spacing = .1f;
    public float resolution = 1;
    public GameObject pPoint;

	
	void Start () {
        Vector2[] points = FindObjectOfType<PathCreator>().path.CalculateEvenlySpacedPoints(spacing, resolution);
        foreach (Vector2 p in points)
        {
           	GameObject g = Instantiate(pPoint, p, Quaternion.identity);
            g.transform.position = p;
            g.transform.localScale = Vector3.one * spacing * .5f;
	        
        }
	}
	
	
}
