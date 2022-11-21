/*
Name: Itteba Gilani
Purpose: Manages fuel system
Date: Nov 7, 2021
*/

//Import necessary packages
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FuelSystem : MonoBehaviour
{   


    [SerializeField] float levelLoadDelay = 1f;

    public float startFuel;     //Starting fuel

    public float maxFuel = 100f;

    public float fuelConsumptionRate;
    public Slider fuelIndicatorSld;
    public Text fuelIndicatorTxt;

    // Start is called before the first frame update
    void Start()
    {
        //cap the fuel
        if(startFuel > maxFuel)
        {
            startFuel = maxFuel;
        }

        fuelIndicatorSld.maxValue = maxFuel;
        UpdateUI();
    }

    public void ReduceFuel() 
    {
        //reduce the fuel level and update the UI
        startFuel -= Time.deltaTime * fuelConsumptionRate;
        UpdateUI();
    }
    void UpdateUI()
    {
        //the value of start fuel (from editor) is equal to the amount of fuel displayed
        fuelIndicatorSld.value  = startFuel;
        fuelIndicatorTxt.text = "Fuel Left: " + startFuel.ToString("0") + " %";

        //if fuel less than 0, restart game after levelLoadDelay
        if(startFuel <= 0)
        {
            startFuel = 0;
            fuelIndicatorTxt.text = "Out of fuel!";
            GetComponent<Movement>().enabled = false;
            Invoke("ReloadLevel", levelLoadDelay);
        }
    }

    //handles reloading the level
    void ReloadLevel()
    {
 
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    
}
