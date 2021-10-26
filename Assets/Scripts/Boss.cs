using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int Hp =1;
    private GameObject boss;
    private Animator anim;

    [SerializeField]
    Transform Player;

    [SerializeField]
    float agroRange;
    
    public float moveSpeed;
    [SerializeField]
    float atkRange;
    bool animatk = false;
    bool deth = false;

    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isdeth", false);
    }
    private void atk1()
    {
        moveSpeed = 0;
        Invoke("atkmotion", 0.5f);
        animatk = false;
    }
    private void atk2()
    {
        anim.SetBool("atk", false);
        moveSpeed = 3;
        animatk = true;
    }

    private void bossdeth()
    {
        moveSpeed = 0;
        deth = true;
        anim.SetBool("isdeth", true);
        Destroy(gameObject, 0.4f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            bossdeth();
        }
    }

    void Update()
    {
        if(Hp == 0)
        {
            bossdeth();   
        }

        float distToplayer = Vector2.Distance(transform.position, Player.position);
        if(distToplayer < agroRange && deth == false)
        {
            ChasePlayer();
        }
        else
        {
            StopChasePlayer();
        }
        if (distToplayer < atkRange)
        {
            Invoke("atk1", 0.2f);
        }
        else
        {
            Invoke("atk2", 0.2f);
        }
    }
    void atkmotion()
    {
        anim.SetBool("run", false);
        anim.SetBool("atk", true);
        
    }
    void ChasePlayer()
    {
        if (animatk)
        {
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }
        
        if(transform.position.x <= Player.position.x)
        {
            rb2d.velocity = new Vector2(8, 0);
            transform.localScale = new Vector2(1, 1);
            
        }
        else if (transform.position.x > Player.position.x)
        {
            rb2d.velocity = new Vector2(-8, 0);
            transform.localScale = new Vector2(-1, 1);
          
        }
    }
    private void StopChasePlayer()
    {
        anim.SetBool("run", false);
        rb2d.velocity = new Vector2(0, 0);
    }
    public void TackDamge(int damge)
    {
        Hp = Hp - damge;
        StopChasePlayer();
    }
    
}
