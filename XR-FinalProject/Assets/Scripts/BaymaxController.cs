using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

using TMPro;
using System;
public class BaymaxController : MonoBehaviour
{  // This script is responsible for Baymax's and the game's state depending on the players actions
    public enum State {Intro, Idle, Checkup, Explain, Demo };
    public State currentState;
    private bool idling = false;

    private AudioSource audioSrc;
    [SerializeField] AudioClip[] clips;

    public TextMeshProUGUI txt;
    string start = "";
    string end = "";

    private Animator animationController;
    private const int WALK_LAYER = 0;
    private const int HEAD_LAYER = 1;
    private const int WAVING_LAYER = 2;
    private const int POINTING_LAYER = 3;
    private const int HEADN_LAYER = 4;

    IEnumerator intro, checkup, idle, bactine, bandaid, thermometer;
    void Start()
    {
        intro = IntroCoroutine();
        checkup = HealthCheckupCoroutine();
        bactine = BactineCoroutine();
        idle = IdleCoroutine();
        bandaid = BandAidCoroutine();
        thermometer = ThermometerCoroutine();

        currentState = State.Intro;
        start = Enum.GetName(typeof(State), currentState);
        txt.text = start + "Startup";
        audioSrc = GetComponent<AudioSource>();
        animationController = GetComponent<Animator>();
        StartCoroutine("IntroCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = start + "\n" + end;
        start = Enum.GetName(typeof(State), currentState);
        //prevents Idle() from being called every fucking frame
        if (currentState == State.Idle && !idling)
        {
            StartCoroutine("IdleCoroutine");
        }
    }

    public void Idle()
    {
        StopAllCoroutines();
        currentState = State.Idle;
        start = "Idle";
        end = "";
        StartCoroutine("IdleCoroutine");
    }

    public void BactineDemo()
    {
        end = "Bactine Grabbed";
        if (currentState == State.Checkup)
        {
            return;
        }
            
        currentState = State.Demo;
        idling = false;
        StopAllCoroutines();
        StartCoroutine("BactineCoroutine");
    }

    public void BandAidDemo()
    {
        end = "Band Aids Grabbed";
        if (currentState == State.Checkup)
        {
            return;
        }
        currentState = State.Demo;
        idling = false;
        StopAllCoroutines();
        StartCoroutine("BandAidCoroutine");
    }

    public void ThermometerDemo()
    {
        end = "Thermometer Grabbed";
        if (currentState == State.Checkup)
        {
            return;
        }
        currentState = State.Demo;
        idling = false;
        StopAllCoroutines();
        StartCoroutine("ThermometerCoroutine");
    }

    IEnumerator BactineCoroutine()
    {
        end = "Bactine Coroutine in Process";  // display text: reference audio clip
        audioSrc.PlayOneShot(clips[1]);             // play audio clip
        RotatingHead();                             // play explanation animation
        yield return new WaitForSeconds(3.0f);

        ResetRotatingHead();

        // hide text

        Idle();
    }

    IEnumerator BandAidCoroutine()
    {
        end =  "BandAid Coroutine in Process";  // display text: write something ig
        RotatingHead();                             // play explanation animation
        yield return new WaitForSeconds(3.0f);

        ResetRotatingHead();

        // hide text

        Idle();
    }
    
    IEnumerator ThermometerCoroutine()
    {
        end =  "Thermometer Coroutine in Process";// display text: write something abt how baymax's scan function uses the same technology with infrared lights idk googl
        RotatingHead();                             // play explanation animation

        //perhaps add functionality here
        yield return new WaitForSeconds(5.0f);

        ResetRotatingHead();

        // hide text

        Idle();
    }

    IEnumerator IntroCoroutine()
    {
        currentState = State.Intro;
        yield return new WaitForSeconds(5.0f);      // buffer time to avoid jumpscare lmao
        // display text: reference the audio clip

        audioSrc.PlayOneShot(clips[0]);             // play audio clip
       
        WavingHandUp();                             // play wave animation
        yield return new WaitForSeconds(4.0f);
        WavingHandDown();
        yield return new WaitForSeconds(3.0f);
        // hide text

        Idle();//checkup);
    }

    IEnumerator IdleCoroutine()
    {
        end = "idling";
        idling = true;
        // periodically display text to interact with items
        // display text: ??? write something ig
        yield return new WaitForSeconds(8f);
        // hide text
        yield return new WaitForSeconds(15.0f);
        idling = false;
    }

    IEnumerator HealthCheckupCoroutine()
{
    currentState = State.Checkup;

    txt.text = "I will scan you now";
    audioSrc.PlayOneShot(scanClip); // Assuming scanClip has "I will scan you now" audio
    yield return new WaitForSeconds(2.0f);

    txt.text = "Scanning in progress...";
    audioSrc.PlayOneShot(scanningSound); // Play scanning sound for 3 seconds
    yield return new WaitForSeconds(3.0f);

    txt.text = "Scan complete";
    audioSrc.PlayOneShot(completeClip); // Assuming completeClip has "Scan complete" audio
    yield return new WaitForSeconds(1.0f);

    StartCoroutine("IdleCoroutine");
    Idle();
}



    // ANIMATION STUF 
    public void RotatingHead()
    {
        //ResetAnimBools();
        animationController.SetLayerWeight(WALK_LAYER, 0);
        animationController.SetLayerWeight(HEAD_LAYER, 1);
        animationController.SetLayerWeight(WAVING_LAYER, 0);
        animationController.SetLayerWeight(POINTING_LAYER, 0);
        animationController.SetLayerWeight(HEADN_LAYER, 0);
        animationController.SetBool("ResetRotatingHead", false);
        animationController.SetBool("RotatingHead", true);
    }
    public void ResetRotatingHead()
    {
        animationController.SetLayerWeight(WALK_LAYER, 0);
        animationController.SetLayerWeight(HEAD_LAYER, 1);
        animationController.SetLayerWeight(WAVING_LAYER, 0);
        animationController.SetLayerWeight(POINTING_LAYER, 0);
        animationController.SetLayerWeight(HEADN_LAYER, 0);
        animationController.SetBool("RotatingHead", false);
        animationController.SetBool("ResetRotatingHead", true);
    }
    public void Walking()
    {
        //ResetAnimBools();
        animationController.SetLayerWeight(WALK_LAYER, 1);
        animationController.SetLayerWeight(HEAD_LAYER, 0);
        animationController.SetLayerWeight(WAVING_LAYER, 0);
        animationController.SetLayerWeight(POINTING_LAYER, 0);
        animationController.SetLayerWeight(HEADN_LAYER, 0);
        animationController.SetBool("Walking", true);
    }
    public void WavingHandUp()
    {
        //ResetAnimBools();
        animationController.SetLayerWeight(WALK_LAYER, 0);
        animationController.SetLayerWeight(HEAD_LAYER, 0);
        animationController.SetLayerWeight(WAVING_LAYER, 1);
        animationController.SetLayerWeight(POINTING_LAYER, 0);
        animationController.SetLayerWeight(HEADN_LAYER, 0);
        animationController.SetBool("WavingHandUp", true);
    }
    public void WavingHandDown()
    {
        //ResetAnimBools();
        animationController.SetLayerWeight(WALK_LAYER, 0);
        animationController.SetLayerWeight(HEAD_LAYER, 0);
        animationController.SetLayerWeight(WAVING_LAYER, 1);
        animationController.SetLayerWeight(POINTING_LAYER, 0);
        animationController.SetLayerWeight(HEADN_LAYER, 0);
        animationController.SetBool("WavingHandDown", true);
    }
    public void PointingFingerUp()
    {
        //ResetAnimBools();
        animationController.SetLayerWeight(WALK_LAYER, 0);
        animationController.SetLayerWeight(HEAD_LAYER, 0);
        animationController.SetLayerWeight(WAVING_LAYER, 0);
        animationController.SetLayerWeight(POINTING_LAYER, 1);
        animationController.SetLayerWeight(HEADN_LAYER, 0);
        animationController.SetBool("PointingFingerUp", true);
    }
    public void PointingFingerDown()
    {
        //ResetAnimBools();
        animationController.SetLayerWeight(WALK_LAYER, 0);
        animationController.SetLayerWeight(HEAD_LAYER, 0);
        animationController.SetLayerWeight(WAVING_LAYER, 0);
        animationController.SetLayerWeight(POINTING_LAYER, 1);
        animationController.SetLayerWeight(HEADN_LAYER, 0);
        animationController.SetBool("PointingFingerDown", true);
    }
    public void HeadNodding()
    {
        animationController.SetLayerWeight(WALK_LAYER, 0);
        animationController.SetLayerWeight(HEAD_LAYER, 0);
        animationController.SetLayerWeight(WAVING_LAYER, 0);
        animationController.SetLayerWeight(POINTING_LAYER, 0);
        animationController.SetLayerWeight(HEADN_LAYER, 1);
        animationController.SetBool("HeadNodding", true);
    }

    public void ResetAnimBools()
    {
        animationController.SetBool("RotatingHead", false);
        animationController.SetBool("Walking", false);
        animationController.SetBool("WavingHandUp", false);
        animationController.SetBool("WavingHandDown", false);
        animationController.SetBool("PointingFingerUp", false);
        animationController.SetBool("PointingFingerDown", false);
    }
}
