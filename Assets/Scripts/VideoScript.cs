using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

using UnityEngine.SceneManagement;

public class VideoScript : MonoBehaviour
{
    [SerializeField]
    VideoPlayer myVideoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        myVideoPlayer.loopPointReached += VideoFinish;
    }

    void VideoFinish(VideoPlayer vp)
    {
        SceneManager.LoadScene(0);
    }
}
