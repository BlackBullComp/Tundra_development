using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class ActionScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Image HealthBar;
    public bool attack;
    public bool triggered;
    public int collectedwoods;
    public GameObject log;
    public GameObject Barscanvas;
    public GameObject AddedCanvas;
    public GameObject Cam;
    public GameObject Axe;
    float hunger;
    public string menulevel;
    float thirstyplayer;
    public bool take_enabled;
    public bool take_axe_enabled;
    public int takedobject_toinventory;
    public Animator armanimator; 
    GameObject takeableobject;
    public bool axetaked;
    bool take_axe_tool;
    float percent;
    
     GameObject collidedobject;
    public float Health = 100;
    void Start()
    {
        AddedCanvas.SetActive(false);
        hunger = Barscanvas.GetComponent<hungrybarscript>().Hunger;
        thirstyplayer = Barscanvas.GetComponent<ThirstyBar>().thirsty;
        take_enabled = false;
        axetaked = false;
    }

    // Update is called once per frame
    

    void Update()
    {
        percent = Health / 100;
        HealthBar.fillAmount = percent;
        
        if (attack ==true && triggered == true)
        {

            StartCoroutine(givedamage_totree());



        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            take_axe_tool = !take_axe_tool;
        }

        if (take_axe_tool == true && axetaked == true)
        {
            Axe.SetActive(true);
        }
        else
        {
            Axe.SetActive(false);
        }

        if (Input.GetMouseButton(0) && axetaked == true && take_axe_tool == true)
        {
            
            armanimator.SetBool("attack", true);
            StartCoroutine(attackcontroller());
        }
        else
        {
            

            armanimator.SetBool("attack", false);
        }

        if (Health <= 0)
        {
            Health = 0;
            Die();
        }


        if(Input.GetKeyDown(KeyCode.E))
        {
            if (take_enabled == true)
            {
                armanimator.SetBool("take", true);
                Axe.SetActive(false);
                StartCoroutine(handsdelay());
            }else {
            if (take_axe_enabled == true)
            {
                armanimator.SetBool("take", true);
                StartCoroutine(axetakedelay());
                
            }
            else
            {
               axetaked= false;
            }
            }
        }


    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "water")
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (other.gameObject.tag == "obj")
        {
            Debug.Log("obj_collided");
            takeableobject = other.gameObject; 
            take_enabled = true;
        }
        else
        {
            take_enabled = false;
            
        }
        if (other.gameObject.tag == "axe")
        {
            Debug.Log("axecollided");
            takeableobject = other.gameObject;
            take_axe_enabled = true;
        }
        else
        {
            take_axe_enabled = false;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {

            if (other.gameObject.tag == "Tree")
            {

            Debug.Log("collided");
            collidedobject = other.gameObject;
            triggered = true;
                
            }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Tree")
        {

            Debug.Log("exited_c");
            collidedobject = other.gameObject;
            triggered = false;

        }
    }


    public void SpawnLog()
    {
        Instantiate(log, collidedobject.gameObject.transform.position, Quaternion.Euler(-90, 5, 0));
        collectedwoods += 3;
        AddedCanvas.SetActive(true);
        StartCoroutine(timer());
    }

    public void Die()
    {
        Debug.Log("dead");
        Application.LoadLevel(menulevel);
    }

    IEnumerator timer()
    {
        
        yield return new WaitForSeconds(1.2f);
        AddedCanvas.SetActive(false);

    }

    IEnumerator handsdelay()
    {
        
        yield return new WaitForSeconds(2);
        Destroy(takeableobject);
        takedobject_toinventory += 1;
        Debug.Log(takedobject_toinventory);

        armanimator.SetBool("take", false);
    }

    IEnumerator attackcontroller()
    {
        attack = true;
        yield return new WaitForSeconds(1);


        Debug.Log("attacked");
        attack = false;
        yield break;
    }

    IEnumerator givedamage_totree()
    {
        yield return new WaitForSeconds(1);
        collidedobject.GetComponent<treehealt>().tree_healt -= 1;
    }

    IEnumerator taketheaxe()
    {

        yield return new WaitForSeconds(0.4f);
        Axe.SetActive(true);
        
    }

    IEnumerator axetakedelay()
    {

        yield return new WaitForSeconds(2);
        Destroy(takeableobject);
        takedobject_toinventory += 1;
        Debug.Log(takedobject_toinventory);
        axetaked = true;
        armanimator.SetBool("take", false);
    }
}
