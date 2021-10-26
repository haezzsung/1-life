using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearEnemy : MonoBehaviour
{
   
    public Transform Spos;
    public GameObject Spear;
    private Animator anim;

    bool isatk;

    void Start()
    {
        shoot();
        anim = GetComponent<Animator>();
        isatk = true;
    }

    void Update()
    {
        if(isatk == true)
        {
            anim.SetBool("atk", true);
        }

        else if(isatk == false)
        {
            anim.SetBool("atk", false);
        }
     
    }
    private void shoot()
    {
        isatk = true;
        Instantiate(Spear, Spos.position, transform.rotation);
        Invoke("isatkfalse", 0.5f);
    }
    void isatkfalse()
    {
        isatk = false;
        Invoke("shoot", 1.3f);
    }
}
