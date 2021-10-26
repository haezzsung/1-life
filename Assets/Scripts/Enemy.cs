using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int SkelHp = 1;
    bool playerCheak;
    private GameObject skel;
    private Animator anim;
    
    public float speed;
    private bool islive = true;
    bool l = true;
    public void takeDamge(int damge)
    {
        SkelHp = SkelHp - damge;
    }
   
    void Start()
    {
        anim = GetComponent<Animator>();   
    }

  
    void Update()
    {
        if (islive)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if(collison.tag == "side")
        {
            if (l)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                l = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                l = true;
            }
        }
    }

    private void dethMotion()
    {
        anim.SetBool("enDeth", true);
    }
    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void OverPage()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void enemyTakeDamge()
    {
        islive = false;
        Invoke("dethMotion", 0);
        Invoke("DestroySelf", 0.4f);
    }
}
