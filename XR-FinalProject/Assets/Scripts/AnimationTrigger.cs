using UnityEngine;
using System.Collections;

public class AnimationTrigger : MonoBehaviour
{
    // PLEASE READ
    //
    // METHODS HERE HAVE BOON MOVED TO BAYMAXCONTROLLER;
    // THIS SCRIPT IS NOT IN SCENE AND NOT TO BE USED








    private Animator animationController;
    private const int WALK_LAYER = 0;
    private const int HEAD_LAYER = 1;
    private const int WAVING_LAYER = 2;
    private const int POINTING_LAYER = 3;
    
    void Start()
    {
        animationController = GetComponent<Animator>();
    }

    // Methods to trigger the animations
    public void RotatingHead()
    {
        ResetAnimBools();
        animationController.SetLayerWeight(WALK_LAYER, 0);
        animationController.SetLayerWeight(HEAD_LAYER, 1);
        animationController.SetLayerWeight(WAVING_LAYER, 0);
        animationController.SetLayerWeight(POINTING_LAYER, 0);
        animationController.SetBool("RotatingHead", true);
    }
    public void Walking()
    {
        ResetAnimBools();
        animationController.SetLayerWeight(WALK_LAYER, 1);
        animationController.SetLayerWeight(HEAD_LAYER, 0);
        animationController.SetLayerWeight(WAVING_LAYER, 0);
        animationController.SetLayerWeight(POINTING_LAYER, 0);
        animationController.SetBool("Walking", true);
    }
    public void WavingHandUp()
    {
        ResetAnimBools();
        animationController.SetLayerWeight(WALK_LAYER, 0);
        animationController.SetLayerWeight(HEAD_LAYER, 0);
        animationController.SetLayerWeight(WAVING_LAYER, 1);
        animationController.SetLayerWeight(POINTING_LAYER, 0);
        animationController.SetBool("WavingHandUp", true);
    }
    public void WavingHandDown()
    {
        ResetAnimBools();
        animationController.SetLayerWeight(WALK_LAYER, 0);
        animationController.SetLayerWeight(HEAD_LAYER, 0);
        animationController.SetLayerWeight(WAVING_LAYER, 1);
        animationController.SetLayerWeight(POINTING_LAYER, 0);
        animationController.SetBool("WavingHandDown", true);
    }
    public void PointingFingerUp()
    {
        ResetAnimBools();
        animationController.SetLayerWeight(WALK_LAYER, 0);
        animationController.SetLayerWeight(HEAD_LAYER, 0);
        animationController.SetLayerWeight(WAVING_LAYER, 0);
        animationController.SetLayerWeight(POINTING_LAYER, 1);
        animationController.SetBool("PointingFingerUp", true);
    }
    public void PointingFingerDown()
    {
        ResetAnimBools();
        animationController.SetLayerWeight(WALK_LAYER, 0);
        animationController.SetLayerWeight(HEAD_LAYER, 0);
        animationController.SetLayerWeight(WAVING_LAYER, 0);
        animationController.SetLayerWeight(POINTING_LAYER, 1);
        animationController.SetBool("PointingFingerDown", true);
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

    /*
    // Get user inputs from the keyboard
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            RotatingHead();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Walking();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            WavingHandUp();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            WavingHandDown();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            PointingFingerUp();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            PointingFingerDown();
        }
    }
    */

}
