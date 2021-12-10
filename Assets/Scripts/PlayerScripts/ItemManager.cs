using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    #region Variables
    [SerializeField]
    Camera camera;
    //The primary weapon the player is holding
    public GameObject primaryWeaponOnHand;
    //The secondary weapon the player is holding
    public GameObject secondaryWeaponOnHand;
    //The antivenom syringe
    public GameObject antiVenomSyringe;
    public GameObject[] primaryWeaponsList;
    public GameObject[] secondaryWeaponsList;
    //Primary weapons
    bool hasUzi;
    bool hasShotGun;
    bool hasM4;
    bool hasAK;
    //Secondary weapons
    bool hasPistol;
    bool hasAxe;
    //Healing Items
    public bool hasSyringe;
    public SyringeBehavior syringeBehavior;
    PlayerVitals playerVitals;
    #endregion

    #region Monobehavior
    void Start()
    {
        playerVitals = GetComponent<PlayerVitals>();
    }
    void Update()
    {
        WeaponHover();
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            secondaryWeaponOnHand.SetActive(false);
            primaryWeaponOnHand.SetActive(true);
            antiVenomSyringe.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            primaryWeaponOnHand.SetActive(false);
            secondaryWeaponOnHand.SetActive(true);
            antiVenomSyringe.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) && hasSyringe)
        {
            antiVenomSyringe.SetActive(true);
            secondaryWeaponOnHand.SetActive(false);
            primaryWeaponOnHand.SetActive(false);
        }
        if(syringeBehavior.usedShot && !playerVitals.isInfected && !playerVitals.blackWidowInfection)
        {
            syringeBehavior.usedShot = false;
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            ItemPickUp();
        }
    }

    void WeaponHover()
    {
        RaycastHit hit;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 1.25f))
        {
            WorldItemBehavior wIB = hit.transform.GetComponent<WorldItemBehavior>();
            if(wIB != null)
            {
                wIB.isHovered = true;
            }
        }
    }

    void ItemPickUp()
    {
        RaycastHit hit;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 1.25f))
        {
            WorldItemBehavior wIB = hit.transform.GetComponent<WorldItemBehavior>();
            if(wIB != null)
            {
                if(wIB.itemCode < 4)
                {
                    primaryWeaponOnHand.SetActive(false);
                    secondaryWeaponOnHand.SetActive(false);
                    antiVenomSyringe.SetActive(false);
                    primaryWeaponOnHand = primaryWeaponsList[wIB.itemCode];
                    primaryWeaponOnHand.SetActive(true);
                }else if (wIB.itemCode == 4 || wIB.itemCode == 5)
                {
                    primaryWeaponOnHand.SetActive(false);
                    secondaryWeaponOnHand.SetActive(false);
                    antiVenomSyringe.SetActive(false);
                    secondaryWeaponOnHand = secondaryWeaponsList[wIB.itemCode - 4];
                    secondaryWeaponOnHand.SetActive(true);
                }
                wIB.ItemSelect();
            }
        }
    }
    #endregion
}
