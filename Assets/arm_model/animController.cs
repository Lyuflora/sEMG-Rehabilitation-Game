using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // anim.SetBool ("slash", Input.getButton ("Fire1"));
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("Hit01", true);
        }
        else
        {
            anim.SetBool("Hit01", false);
        }
    }
}
