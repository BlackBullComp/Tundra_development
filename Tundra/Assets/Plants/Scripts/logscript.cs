using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logscript : MonoBehaviour
{
    public float spawnRate;
    public GameObject preafabofTree;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnrate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnrate()
    {
        yield return new WaitForSeconds(spawnRate);
        Destroy(gameObject);
    }
}
