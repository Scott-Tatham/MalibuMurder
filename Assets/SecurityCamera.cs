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

    //[Range(-180.0f, 180.0f)]
    //public float fieldOfView = 0.0f;

    private Camera camera;
	// Use this for initialization
	void Start ()
    {
        camera = GetComponent<Camera>();
        if (camera == null)
        {
            Debug.LogWarning("Yo ya didnt assign this to a camera you dunkus");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        //transform.rotation = Quaternion.Euler(0, fieldOfView, 0);
	}
}
