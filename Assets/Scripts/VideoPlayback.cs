using UnityEngine;
using UnityEngine.Video;

public class VideoPlayback : MonoBehaviour
{
    public VideoClip[] videoClips;
    private VideoPlayer video;
    private int videoClipIndex = 0;

    private void Awake()
    {
        video = GetComponent<VideoPlayer>();
    }
    void Start()
    {
        video.clip = videoClips[0];
        video.Play();
    }

    public void playNext()
    {
        videoClipIndex++;
        if (videoClipIndex >= videoClips.Length)
        {
            videoClipIndex = videoClipIndex % videoClips.Length;
        }
        video.clip = videoClips[videoClipIndex];
        video.Play();
    }
    public void playPrevious()
    {
        videoClipIndex = videoClipIndex - 1;
        if (videoClipIndex < 0)
        {
            videoClipIndex = videoClips.Length - 1;
        }
        video.clip = videoClips[videoClipIndex];
        video.Play();
    }
}
