using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{
    public Sprite LiverActivate;
    public bool activated = false;

    // Update is called once per frame
    void Update()
    {
        if(activated){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = LiverActivate;
        }
        
    }

}
