using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A security camera, can be moved via code.
/// </summary>
public class SecurityCamera : MonoBehaviour
{
    [Range(0, 180.0f)]
    public float maxPositiveHorizontal = 0.0f;

    [Range(0, -180.0f)]
    public float maxNegativeHorizontal = 0.0f;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {

	}
}
