using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class ParentCars : MonoBehaviour
{
    public List<GameObject> destroyableCarList = new List<GameObject>();
    public List<GameObject> cars = new List<GameObject>();
    public GameManager gameManager;
    public int maxCarLevel = 1;
    public int maxMergableCarLevel = 1;

    public void CreatingCars()
    {
        GameObject newCar = Instantiate(gameManager.carLevelList[0], transform.parent);
        cars.Add(newCar);
        newCar.transform.parent = transform;
        newCar.SetActive(true);
        FindingMaxLevelCar();
    }

    public bool CanWeMergeCars()
    {
        int sameCarLevelCount = 0;

        foreach(GameObject car in cars)
        {
            Car carScript = car.GetComponent<Car>();
            if(FindingMaxMergableCarLevel(maxCarLevel) == carScript.carLevel)
            {
                sameCarLevelCount++;
            }
            if (sameCarLevelCount >= 3)
            {
                return true;
            }
        }
        return false;
    }

    public void MergeCars()
    { 
        int destroyedCars = 0;

        if (CanWeMergeCars() == true)
        {
            int count = cars.Count;

            for(int i = 0; i < count; i++)
            {
                Car carScript = cars[i].GetComponent<Car>();
                if(carScript.carLevel == maxMergableCarLevel)
                {
                    destroyableCarList.Add(cars[i]);
                    destroyedCars++;
                    if(destroyedCars == 3)
                    {
                        GameObject newCar = Instantiate(gameManager.carLevelList[maxMergableCarLevel], transform.parent);
                        cars.Add(newCar);
                        newCar.transform.parent = transform;
                        newCar.SetActive(true);
                        break;
                    }
                }
            }
            FindingMaxMergableCarLevel(maxCarLevel);
            RemoveAndDestroyCarsFromLists();
            FindingMaxLevelCar();
        }
    }

    public void RemoveAndDestroyCarsFromLists()
    {
        int count = destroyableCarList.Count;

        for(int i=0; i < count; i++)
        {
            Destroy(destroyableCarList[i]);
            cars.Remove(destroyableCarList[i]);
        }
        destroyableCarList.Clear();
    }

    public void FindingMaxLevelCar()
    {
        foreach(GameObject car in cars)
        {
            Car carScript = car.GetComponent<Car>();
            if(carScript.carLevel > maxCarLevel)
            {
                maxCarLevel = carScript.carLevel;
            }
        }
    }
    
    public int FindingMaxMergableCarLevel(int level)
    {
        int sameCarLevelCount = 0;

        foreach(GameObject car in cars)
        {
            Car carScript = car.GetComponent<Car>();
            if(carScript.carLevel == level)
            {
                sameCarLevelCount++;
            }
            if (sameCarLevelCount == 3)
            {
                maxMergableCarLevel = level;
                return level;
            }
        }
        if(level == 1)
        {
            return level;
        }
        return FindingMaxMergableCarLevel(level - 1);
    }
}
