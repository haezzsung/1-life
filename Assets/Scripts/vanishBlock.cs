using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vanishBlock : MonoBehaviour
{
    private int passingcount = 0;
   
    [SerializeField]
    private int passingcountcheak;
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            passingcount += 1;
        }
    }

    void Update()
    {
        if (passingcountcheak == passingcount)
        {
            Destroy(gameObject);
        }
    }
}
