using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Simulate : MonoBehaviour {

    public GameObject niddle;
    public InputField inputVal;
    public Text indicator;
    public Text btnText;
    private long rpmVal;
    private bool isRunning = false;

    private void Start()
    {
        isRunning = false;
    }

    private void Update()
    {
        niddle.gameObject.transform.Rotate(new Vector3(0,0,((Time.deltaTime * 6)) * -1)*rpmVal);
    }

    public void StartSimulation()
    {
        if (!isRunning)
        {
            if (long.TryParse(inputVal.text, out rpmVal))
            {
                isRunning = true;
                indicator.text = "Simulating";
                btnText.text = "Stop";
            }
            else
            {
                rpmVal = 0;
                indicator.text = "Invalid Input";
            }
        }
        else
        {
            rpmVal = 0;
            isRunning = false;
            btnText.text = "Simulate";
            indicator.text = "Stopped";
        }
    }
}
