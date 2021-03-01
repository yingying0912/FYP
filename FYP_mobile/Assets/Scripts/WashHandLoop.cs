using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;
using UnityEngine.Video;

public class WashHandLoop : MonoBehaviour
{
    [SerializeField] GameObject[] HandGestures;
    public static int currentGesture;
    public static bool loopOnce;

    [SerializeField] GameObject washHandVideo;
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] VideoClip[] videos;

    [SerializeField] OutlineEffect outlineEffect;

    // Start is called before the first frame update
    void Start()
    {
        currentGesture = 0;
        HandGestures[currentGesture].SetActive(true);
        HandGestures[currentGesture].GetComponent<AttachmentToggle>().setBacteriaActive();
        for (int i = 1; i < HandGestures.Length; i++)
        {
            HandGestures[i].SetActive(false);
        }
        loopOnce = false;

        washHandVideo.SetActive(true);
        videoPlayer.clip = videos[currentGesture];
        videoPlayer.isLooping = true;
        videoPlayer.SetDirectAudioMute(0, true);
        videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (HandGestures[currentGesture].GetComponent<CheckClean>().isCleaned)
        {
            //gameObject.GetComponent<ChargeEnergy>().Charging();
            HandGestures[currentGesture].SetActive(false);
            HandGestures[currentGesture].GetComponent<AttachmentToggle>().setBacteriaInactive();
            HandGestures[currentGesture].GetComponent<CheckClean>().isCleaned = false;
            
            currentGesture += 1;

            outlineEffect.enabled = true;
            outlineEffect.fillAmount = currentGesture / (float)HandGestures.Length * 0.3f;


            if (currentGesture >= HandGestures.Length)
            {
                loopOnce = true;
                washHandVideo.SetActive(false);
                currentGesture -= HandGestures.Length;
                outlineReset();
            }

            HandGestures[currentGesture].SetActive(true);
            HandGestures[currentGesture].GetComponent<AttachmentToggle>().setBacteriaActive();

            if (washHandVideo.active)
            {
                videoPlayer.clip = videos[currentGesture];
                videoPlayer.isLooping = true;
                videoPlayer.SetDirectAudioMute(0, true);
                videoPlayer.Play();
            }
        }
    }

    public void setInactive()
    {
        HandGestures[currentGesture].GetComponent<AttachmentToggle>().setBacteriaInactive();
    }

    public void outlineReset()
    {
        outlineEffect.fillAmount = 0;
        outlineEffect.enabled = false;
    }
}
