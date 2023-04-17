using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutdown : MonoBehaviour
{
    public GameObject thistree;
    public int treeHealth = 5;
    private bool isFallen = false;
    public GameObject P;
    public GameObject LOG;
    public GameObject Spawner;


    private void Start()
    {
    }


    private void Update()
    {
        if (treeHealth <= 0 && isFallen == false)
        {
            Rigidbody rb = thistree.AddComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.AddForce(Vector3.forward, ForceMode.Impulse);
            StartCoroutine(destroytree());
            isFallen = true;
        }

        if (treeHealth <= 0)
        {
            treeHealth = 0;
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "tacticalaxe" && P.GetComponent<ActionScript>().attack == true)
        {
            treeHealth -= 1;
        }
    }
    private IEnumerator destroytree()
    {
        yield return new WaitForSeconds(5);
        Destroy(thistree);
        Instantiate(LOG, Spawner.transform.position,Quaternion.identity);
        
    }
}
