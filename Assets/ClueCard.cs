using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Show/hide the cluecard based on mouse clicks
/// </summary>
public class ClueCard : MonoBehaviour
{

    private Animator animator;
    private bool shown = true;
	// Use this for initialization
	void Start ()
    {

        animator = GetComponent<Animator>();

        if (shown)
            animator.Play("ShowPaper");

    }

    // Update is called once per frame
    void Update ()
    {
		if (Input.GetMouseButtonDown(0))
        {
            if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "ShowPaper")
                animator.Play("HidePaper");
            else
                animator.Play("ShowPaper");
        }
	}
}
