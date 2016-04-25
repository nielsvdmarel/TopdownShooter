using UnityEngine;
using System.Collections;

public class animController : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Fire1"))
        {

            anim.SetBool("shootup", true);

        }
        else
        {
            anim.SetBool("shootup", false);
        }

        anim.SetFloat("Speed", Input.GetAxis("Horizontal"));

        if (Input.GetButton("upwalk") || (Input.GetButton("leftwalk")|| (Input.GetButton("rightwalk")||(Input.GetButton("underwalk")))))
        {

            anim.SetBool("shootwalk", true);

        }
        else
        {
            anim.SetBool("shootwalk", false);
        }

    }
}
