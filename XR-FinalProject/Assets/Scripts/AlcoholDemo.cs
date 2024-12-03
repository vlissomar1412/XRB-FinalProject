using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcoholDemo : MonoBehaviour
{
    GameObject baymax;
    BaymaxController baymaxCont;

    // Start is called before the first frame update
    private void Start()
    {
        baymaxCont = baymax.GetComponent<BaymaxController>();
    }
    public void StartDemo()
    {
        baymaxCont.AlcoholDemo();
    }

    public void EndDemo()
    {
        baymaxCont.Idle();
    }
}
