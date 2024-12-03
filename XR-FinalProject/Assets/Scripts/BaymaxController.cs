using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class BaymaxController : MonoBehaviour
{  // This script is responsible for Baymax's and the game's state depending on the players actions
    // tbh im a little confused w this myself

    public InputDevice leftController, rightController;
    public enum State { Idle, Checkup, Explain, Demo };

    GameObject grabbedObj;
    // Start is called before the first frame update
    public State currentState;
    void Start()
    {
        currentState = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {

        /*
        switch(currentState)
        {
            case State.Idle:
                // baymax makes idle chatter
                break;
            case State.Checkup:
                // call checkup event here 
                break;
            case State.Explain:
                // call explanation event here 
                break;
            case State.Demo:
                // call demo event here
                break;
        }
        */

    }

    public void AlcoholDemo()
    {
        currentState = State.Demo;
        AlchoholCoroutine();

    }

    IEnumerator AlchoholCoroutine()
    {
        yield return new WaitForSeconds(5.0f);
        Idle();
    }


    public void Idle()
    {
        currentState = State.Idle;
    }
}
