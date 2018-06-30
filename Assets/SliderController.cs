using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Control a cameras rotation from a UI element.
/// </summary>
public class SliderController : MonoBehaviour
{

    public SecurityCamera cameraToControl;
    private Slider slider;

	// Use this for initialization
	void Start ()
    {
        slider = GetComponent<Slider>();

        if (cameraToControl != null) //If we've been given a cam in the inspector, set 'er up.
            SetCamera(cameraToControl);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (cameraToControl == null)
            return; //Well we aint much use is we?

        cameraToControl.transform.rotation = Quaternion.Euler(0, slider.value, 0);
    
    }

    /// <summary>
    /// Set which camera this slider controls.
    /// </summary>
    /// <param name="cam">Cam to control</param>
    public void SetCamera(SecurityCamera cam)
    {
        cameraToControl = cam;
        slider.maxValue = cam.maxPositiveHorizontal; slider.minValue = cam.maxNegativeHorizontal;
        slider.value = cameraToControl.transform.rotation.y;
    }
}
