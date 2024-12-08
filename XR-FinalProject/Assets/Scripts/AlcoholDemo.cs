using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcoholDemo : MonoBehaviour
{
    public GameObject baymax;
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
        StartCoroutine(baymaxCont.IdleCoroutine());
    }
}
