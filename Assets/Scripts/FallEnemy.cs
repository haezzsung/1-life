using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallEnemy : MonoBehaviour
{

    bool isground;
    [SerializeField]
    Transform cheakBox;
    [SerializeField]
    float cheakRaidus;
    [SerializeField]
    LayerMask islayer;
    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void fallenemyDeth()
    {
        anim.SetBool("deth" , true);
        Invoke("dethself", 0.2f);
    }
    private void dethself()
    {
        Destroy(gameObject);
    }


    void Update()
    {
        isground = Physics2D.OverlapCircle(cheakBox.position, cheakRaidus, islayer);

        if (isground)
        {
            anim.SetBool("isGrounded", true);

        }
        else if (!isground)
        {
            anim.SetBool("isGrounded", false);
        }
    }
}
