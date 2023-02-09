using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treehealt : MonoBehaviour
{
    public int tree_healt;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (tree_healt <= 0)
        {
            tree_healt= 0;
            Destroy(gameObject);
            player.GetComponent<ActionScript>().SpawnLog();
        }
    }
}
