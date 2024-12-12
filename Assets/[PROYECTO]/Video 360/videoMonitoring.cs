using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class videoMonitoring : MonoBehaviour
{
    VideoPlayer video;
    void Start()
    {
        video = this.GetComponent<UnityEngine.Video.VideoPlayer>();
        video.loopPointReached += VideoTerminado;
    }
    void VideoTerminado(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("VideoTerminado");
        //SceneManager.LoadSceneAsync(escenaVuelta);
    }
}