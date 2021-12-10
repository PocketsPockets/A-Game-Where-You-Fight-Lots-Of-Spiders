using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBackButton : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public BoxCollider boxCollider;
    void Update()
    {
        meshRenderer.enabled = true;
        boxCollider.enabled = true;
    }
}
