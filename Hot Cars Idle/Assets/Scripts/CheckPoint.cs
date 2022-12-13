using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public ParentCars parentCars;
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Car")
        {
            parentCars.CarInformationAtCheckPoint(collider.gameObject);
        }
    }
}
