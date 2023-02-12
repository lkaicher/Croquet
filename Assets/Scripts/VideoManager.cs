using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    private float timer = 27f;

    public string url;
    public VideoPlayer vidplayer;

    // Start is called before the first frame update
    void Start()
    {
        vidplayer = GetComponent<VideoPlayer>();
        vidplayer.url = "https://jeremybrunelle.github.io/video/cutscene.mp4";
        vidplayer.Play();
    }




    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}





