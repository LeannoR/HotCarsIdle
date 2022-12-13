using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timeRemaining = 1f;
    public int dolars = 0;
    public int mergeCarCost = 10;
    public int createCarCost = 5;
    public List<GameObject> carLevelList = new List<GameObject>();

    public void Update()
    {
        CarSpeedBoost();
    }
    public void CarSpeedBoost()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            timeRemaining = 1f;
            Time.timeScale = 2f;
        }
        if(timeRemaining <= 0)
        {
            Time.timeScale = 1f;
        }
        timeRemaining -= 1 * Time.deltaTime;
    }
    public void AddingMoneyFromCheckPoint(int income)
    {
        dolars += income;
        Debug.Log(dolars);
    }
    public void MergeSalary()
    {
        dolars -= mergeCarCost;
        mergeCarCost *= 2;
    }
    public void CreateCarSalary()
    {
        dolars -= createCarCost;
        createCarCost += 5;
    }
    public bool CanWeAffordCreateCarSalary()
    {
        if (dolars >= createCarCost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CanWeAffordMergeSalary()
    {
        if(dolars >= mergeCarCost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

