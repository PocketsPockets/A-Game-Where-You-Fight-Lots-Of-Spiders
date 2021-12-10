using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItemBehavior : MonoBehaviour
{
    #region Variables
    public Material[] materials;
    public GameObject[] worldObjects;
    public int itemCode;
    public bool isHovered;
    public bool isPermanent = false;
    #endregion

    #region Monobehavior
    void Update()
    {
        if(isHovered)
        {
            HoverItem();
        }else
        {
            worldObjects[0].GetComponent<MeshRenderer>().material = materials[0];
            worldObjects[1].GetComponent<MeshRenderer>().material = materials[0];
        }
    }
    #endregion

    #region Custom
    public void HoverItem()
    {
        worldObjects[0].GetComponent<MeshRenderer>().material = materials[1];
        worldObjects[1].GetComponent<MeshRenderer>().material = materials[1];
        isHovered = false;
    }

    public void ItemSelect()
    {
        if (!isPermanent)
        {
            Destroy(this.gameObject);
        }
        else return;
    }
    #endregion
}
