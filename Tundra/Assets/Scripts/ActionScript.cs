using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ActionScript : MonoBehaviour
{
    //Setup:
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
    public GameObject PauseCanvas;
    public GameObject Axeininventory;
    public GameObject Axeonhand;
    public TMP_Text woodcount;
    public GameObject WoodIcon;
    GameObject collidedobject;
    public float Health = 100;
    public bool Paused;
    public GameObject LogPref;
    public GameObject droplogpref;
    public bool logsactive = false;
    public bool hadspawned = false;
    void Start()
    {
        LogPref.SetActive(false);
        AddedCanvas.SetActive(false);
        hunger = Barscanvas.GetComponent<hungrybarscript>().Hunger;
        thirstyplayer = Barscanvas.GetComponent<ThirstyBar>().thirsty;
        take_enabled = false;
        axetaked = false;
        PauseCanvas.SetActive(false);
        Axeininventory.SetActive(false);
        Axeonhand.SetActive(false);
        
    }

    // Update is called once per frame
    

    void Update()
    {
        LogPref.SetActive(logsactive);

        woodcount.text = collectedwoods.ToString();

        if (PlayerPrefs.GetString("Walking","walk") == "walk")
        {
            armanimator.SetBool("ismoving",true);
        }
        else
        {
            armanimator.SetBool("ismoving",false);
        }


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
            Axeininventory.SetActive(false);
            Axeonhand.SetActive(true);
        }
        else
        {
            Axe.SetActive(false);
            Axeininventory.SetActive(true);
            Axeonhand.SetActive(false);
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


        if(Input.GetKeyDown(KeyCode.E) && take_axe_enabled == true || take_enabled == true)
        {
            if (take_enabled == true)
            {
                armanimator.SetBool("take", true);
                Axe.SetActive(false);

                Axeininventory.SetActive(true);
                Axeonhand.SetActive(false);
                StartCoroutine(handsdelay());

            }else {
            if (take_axe_enabled == true)
            {
                armanimator.SetBool("take", true);
                StartCoroutine(axetakedelay());
                Axeininventory.SetActive(false);
                Axeonhand.SetActive(true);
                }
            else
            {
                    axetaked= false;
                    Axeininventory.SetActive(false);
                    Axeonhand.SetActive(false);
            }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale =0f;
            PauseCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            GetComponent<FirstPersonController>().enabled = false;
            Paused = true;
        }

        if (Input.GetKey(KeyCode.Tab))
        {
            Map.SetActive(true);
            armanimator.SetBool("look" , true);
        }
        else
        {
            Map.SetActive(false);   
            armanimator.SetBool("look", false);
        }

        if (GetComponent<FirstPersonController>().isSprinting == true)
        {
            Axe.SetActive(false);

            armanimator.SetBool("attack", false);
        }

        if (axetaked == false)
        {

            Axeininventory.SetActive(false);
            Axeonhand.SetActive(false);
        }

        if (collectedwoods <= 0)
        {
            collectedwoods = 0;
            WoodIcon.SetActive(false);
        }
        else
        {
            WoodIcon.SetActive(true);

        }

        if (GetComponent<Inventory>().openInventory == false || Paused == false)
        {

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }

        if (logsactive == true)
        {
            Axe.SetActive(false);
            GetComponent<FirstPersonController>().enableSprint = false;
            GetComponent<FirstPersonController>().useSprintBar = false;
        }
        else
        {
            
            GetComponent<FirstPersonController>().enableSprint = true;
            GetComponent<FirstPersonController>().useSprintBar = true;
        }

        if (Input.GetKeyDown(KeyCode.G) && hadspawned == false && logsactive == true)
        {
            logsactive = false;
            Vector3 tr = new Vector3(this.transform.position.x + 2, transform.position.y + 1, transform.position.z + 2); 
            Instantiate(droplogpref, tr,Quaternion.identity);
            armanimator.SetBool("wood", false);
        }

    }
    


    public GameObject Map;

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

        GetComponent<FirstPersonController>().playerCanMove = false;
        GetComponent<FirstPersonController>().cameraCanMove = false;
        yield return new WaitForSeconds(2);
        Destroy(takeableobject);
        takedobject_toinventory += 1;
        Debug.Log(takedobject_toinventory);
        axetaked = true;
        armanimator.SetBool("take", false);
        GetComponent<FirstPersonController>().playerCanMove = true;
        GetComponent<FirstPersonController>().cameraCanMove = true;
    }
}
