using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class BaymaxController : MonoBehaviour
{  // This script is responsible for Baymax's and the game's state depending on the players actions
    // tbh im a little confused w this myself

    // public InputDevice leftController, rightController;
    public enum State {Intro, Idle, Checkup, Explain, Demo };
    public State currentState;
    private bool idling = false;

    private AudioSource audioSrc;
    [SerializeField] AudioClip[] clips;
    private AnimationTrigger animTrig;


    IEnumerator intro, alcohol, idle, bandaid, checkup;
    // GameObject grabbedObj;
    // Start is called before the first frame update
    void Start()
    {
        intro = IntroCoroutine();
        alcohol = AlchoholCoroutine();
        idle = IdleCoroutine();
        bandaid = BandAidCoroutine();
        checkup = HealthCheckupCoroutine();


        currentState = State.Idle;
        animTrig = GetComponent<AnimationTrigger>();
        audioSrc = GetComponent<AudioSource>();
        StartCoroutine(intro);
    }

    // Update is called once per frame
    void Update()
    {
        //prevents Idle() from being called every fucking frame
        if(currentState == State.Idle && !idling)
        {
            StartCoroutine(idle);
        }
    }

    public void AlcoholDemo()
    {
        if (currentState == State.Idle)
        {
            currentState = State.Demo;
            StartCoroutine(alcohol);
        }
    }

    public void BandAidDemo()
    {
        if (currentState == State.Idle)
        {
            currentState = State.Demo;
            StartCoroutine(bandaid);
        }
    }


    IEnumerator AlchoholCoroutine()
    {
        currentState = State.Explain;
        // display text: reference audio clip
        audioSrc.PlayOneShot(clips[1]);             // play audio clip
        // play explanation animation
        yield return new WaitForSeconds(5.0f);
        // hide text
    }

    IEnumerator BandAidCoroutine()
    {
        currentState = State.Explain;
        // display text: write something ig
        // play explanation animation
        yield return new WaitForSeconds(5.0f);
        // hide text
    }

    IEnumerator IntroCoroutine()
    {
        currentState = State.Intro;
        yield return new WaitForSeconds(5.0f);      // buffer time to avoid jumpscare lmao
        // display text: reference the audio clip

        audioSrc.PlayOneShot(clips[0]);             // play audio clip
       
        animTrig.WavingHandUp();                    // play wave animation
        yield return new WaitForSeconds(3.0f);
        animTrig.WavingHandDown();
        yield return new WaitForSeconds(3.0f);
        // hide text

        StartCoroutine(checkup);
    }


    public IEnumerator IdleCoroutine()
    {
        currentState = State.Idle;
        idling = true;
        // periodically display text to interact with items
        // display text: ??? write something ig
        yield return new WaitForSeconds(8f);
        // hide text
        yield return new WaitForSeconds(15.0f);
        idling = false;
    }

    public IEnumerator HealthCheckupCoroutine()
    {
        currentState = State.Checkup;
        // edit code from here on
        yield return new WaitForSeconds(5f);

        StartCoroutine(idle);
    }
}
