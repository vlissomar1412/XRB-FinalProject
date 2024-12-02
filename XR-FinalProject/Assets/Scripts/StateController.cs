using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class StateController : MonoBehaviour
{
    // This script is responsible for Baymax's and the game's state depending on the players actions
    // tbh im a little confused w this myself

    public InputDevice leftController, rightController;
    private enum State {Idle, Checkup, Explain, Demo};
    // Start is called before the first frame update
    [SerializeField] State currentState;
    void Start()
    {
        currentState = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
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
        
    }
}
