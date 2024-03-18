using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimation : MonoBehaviour
{
    private Animator Anim = null;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Anim.SetBool("TurnLeft", true);
            Anim.SetBool("TurnRight", false);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Anim.SetBool("TurnLeft", false);
            Anim.SetBool("TurnRight", false);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Anim.SetBool("TurnLeft", false);
            Anim.SetBool("TurnRight", true);
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            Anim.SetBool("TurnLeft", false);
            Anim.SetBool("TurnRight", false);
        }
    }
}
