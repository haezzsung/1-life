using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    [SerializeField]
    float speed = 15f;

    [SerializeField]
    int direction = -1;

    void Start()
    {
        Invoke("Destroyself", 2f);
        if (direction == -1) //왼쪽
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else if (direction == 1) // 오른쪽
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }

        void Update()
    {
        transform.Translate(direction * transform.right * speed * Time.deltaTime);
    }
    private void Destroyself()
    {
        Destroy(gameObject);
    }
}
