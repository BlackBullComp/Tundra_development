using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Takethelogonhand : MonoBehaviour
{

    ActionScript P;
    public int collected_log = 0;
    // Start is called before the first frame update
    void Start()
    {
        P = GameObject.Find("FirstPersonController").GetComponent<ActionScript>();
        P.LogPref.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        collected_log = PlayerPrefs.GetInt("log_count",0);


    }


    void show_logs()
    {
        P.armanimator.SetBool("wood", true);
        P.Axe.SetActive(false);
        P.logsactive = true;
    }

    void novisibilityfrombegin_log()
    {

        P.logsactive = false;
    }

}
