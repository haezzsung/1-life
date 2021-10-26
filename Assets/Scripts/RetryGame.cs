using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class RetryGame : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float dethtime;
    public Transform buttonscale;
    Vector3 defaultscale;
   
    void Start()
    {
        defaultscale = buttonscale.localScale;
       
    }

   
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("MainGame");
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void Credits()
    {
        SceneManager.LoadScene("credit");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void exit()
    {
        Application.Quit();
    }

    public void OnPointerExit(PointerEventData eventData) => buttonscale.localScale = defaultscale;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector3 vector3 = defaultscale * 1.2f;
        buttonscale.localScale = vector3;
    }
}
