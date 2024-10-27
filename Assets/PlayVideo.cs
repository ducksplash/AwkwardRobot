using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer theVidPlayer;
    public TutorialVideo selectedVideo;
    public List<VideoClip> TutorialClips;

    private void OnEnable()
    {
        StopTheVideo();
        theVidPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath,"1.mp4");
        theVidPlayer.Play();
    }


    // Start is called before the first frame update
    public void PlayTheVideo()
    {
        switch(selectedVideo)
        {
            case TutorialVideo.one: 
                theVidPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath,"1.mp4");
                theVidPlayer.Play();
                break;
            case TutorialVideo.two:
                theVidPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath,"2.mp4");
                theVidPlayer.Play();
                break;
            case TutorialVideo.three:
                theVidPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath,"3.mp4");
                theVidPlayer.Play();
                break;
            case TutorialVideo.four:
                theVidPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath,"4.mp4");
                theVidPlayer.Play();
                break;
        }
    }

    public void StopTheVideo()
    {
        theVidPlayer.Stop();
    }
}

public enum TutorialVideo
{
    one,
    two,
    three,
    four
}