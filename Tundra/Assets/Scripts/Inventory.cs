using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{


    //inventory
    public bool openInventory;
    //sonradan düzeltilecek
    public GameObject InventoryLayout;
    public Camera Cam;

    //
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            openInventory = !openInventory;
        }

        if (openInventory)
        {
            InventoryLayout.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            GetComponent<FirstPersonController>().cameraCanMove = false;
            GetComponent<FirstPersonController>().playerCanMove = false;
            Cam.GetComponent<Camera>().fieldOfView = 100;
            Cam.gameObject.transform.rotation = Quaternion.Euler(45,0, 0);
        }
        else
        {
            InventoryLayout.SetActive(false);


            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            GetComponent<FirstPersonController>().cameraCanMove = true;
            GetComponent<FirstPersonController>().playerCanMove = true;

            Cam.GetComponent<Camera>().fieldOfView = 60;
        }
    }

  
}
