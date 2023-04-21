using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{


    //inventory
    public bool openInventory;
    public GameObject InventoryLayout;
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
        }
        else
        {
            InventoryLayout.SetActive(false);

            GetComponent<FirstPersonController>().cameraCanMove = true;
            GetComponent<FirstPersonController>().playerCanMove = true;
        }
    }

  
}
