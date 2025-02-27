using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scroller : MonoBehaviour 
{

    [SerializeField] public float scrollSpeed = 0.3f;

    private float offset;
    private Material backgroundMaterial;


    void Start()
    {
        backgroundMaterial = GetComponent<Renderer>().material;
    }

    void Update() 
    {
        offset+= (scrollSpeed * Time.deltaTime)/10;
        backgroundMaterial.SetTextureOffset("_MainTex", new Vector2(offset,0));
    }

}
