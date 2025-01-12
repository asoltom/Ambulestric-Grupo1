using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class videoMonitoring : MonoBehaviour
{
    VideoPlayer video;
    public string escenaVuelta;
    void Start()
    {
        video = this.GetComponent<UnityEngine.Video.VideoPlayer>();
        video.loopPointReached += VideoTerminado;
    }
    void VideoTerminado(UnityEngine.Video.VideoPlayer vp)
    {
        //Debug.Log("VideoTerminado");
        SceneManager.LoadSceneAsync(escenaVuelta);
    }
}