/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private AudioSource audioSource;
    private GameObject[] musics;

    void Awake()
    {
        musics = GameObject.FindGameObjectsWithTag("Music");
        if (musics.Length >=2)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
    }
    private void PlayMusic()
    {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

  

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/