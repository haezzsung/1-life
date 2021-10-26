using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public GameObject fire;
    public Transform pos;
    private Animator anim;
    public static bool wizardAlive = true;
  
    private float curtime;
    public float cooltime;
    void Start()
    {
        anim = GetComponent<Animator>();
    
    }
    public void DestroyWizard()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if(curtime <= 0)
        {
            if (wizardAlive)
            {
                Instantiate(fire, pos.position, transform.rotation);
                anim.SetBool("wiAtk", true);
            }
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) //사망
        {
            anim.SetBool("wizDeth", true);
            Invoke("DestroyWizard", 0.2f);
        }
    }
}
