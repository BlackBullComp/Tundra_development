using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Tree : MonoBehaviour
{

    public float Damage;
    public GameObject Player;
    Vector3 SpawnTransform;
    bool get_damage;
    bool azalma;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<ActionScript>().attack == true && azalma == true)
        {
            
            get_damage = true;
        }
        else
        {
            get_damage  = false;
        }

        if (azalma == true)
        {
            time = 1;
            StartCoroutine(DamageTime());
        }
        else
        {
            time= 0;
            StopCoroutine(DamageTime());
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            azalma = true;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            azalma = false;
            StopCoroutine(DamageTime());

        }
    }

    IEnumerator DamageTime()
    {
        yield return new WaitForSeconds(time);
        if (get_damage == true)
        {
            Player.GetComponent<ActionScript>().collectedwoods += 1;
            Debug.Log(Player.GetComponent<ActionScript>().collectedwoods);
        }
    }

}
