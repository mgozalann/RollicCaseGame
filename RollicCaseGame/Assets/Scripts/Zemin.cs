using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zemin : MonoBehaviour
{
    PlatformController platformController;
    bool carptiMi;
    
    void Start()
    {
        carptiMi = false;
       platformController = GetComponentInParent<PlatformController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Obje"))
        {
            if (!carptiMi) 
            {
                platformController.ObjeZemineÇarptý();
                Debug.Log("zemine çarptý;");
                carptiMi = true;
            }           
            collision.gameObject.tag = "Untagged";
            platformController.objectCount++;
            Destroy(collision.gameObject, 3f);
        }
    }
}
