using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Simulate : MonoBehaviour {

    public GameObject niddle;
    public InputField inputVal;
    public Text indicator;
    public Text btnText;
    public Text diplayTimer;
    public Text displayRotation;
    private float timer;
    private float rpmVal;
    private float hours, minutes, seconds;
    private float zRotation;
    private float angle1, angle2, angleDif;
    private string strHours, strMinutes, strSeconds;
    private bool isRunning = false;
    private Quaternion originalPos;
    private float rotationCount, rotationCountHold;

    private void Start()
    {
        originalPos = niddle.gameObject.transform.rotation;
        isRunning = false;
        rpmVal = 0;
        rotationCount = 0;
    }

    private void Update()
    {
        if (isRunning)
        {
            if (float.TryParse(inputVal.text, out rpmVal))
            {
                indicator.text = "Simulating";
                timer += Time.deltaTime;

                zRotation = (Time.deltaTime * 6) * -1;

                CountAndRotateGameObject();
            }
            else
            {
                indicator.text = "Invalid";
                timer += Time.deltaTime;
            }
        }
    }

    private void CountAndRotateGameObject()
    {
        angle1 = niddle.gameObject.transform.rotation.eulerAngles.z;
        niddle.gameObject.transform.Rotate(new Vector3(0, 0, zRotation * rpmVal));
        angle2 = niddle.gameObject.transform.rotation.eulerAngles.z;
        angleDif = angle1 - angle2;

        if (angleDif < 0)
        {
            ++rotationCount;
            rotationCountHold = rotationCount - 1;
        }
    }

    public void StartSimulation()
    {
        if (!isRunning)
        {
            if (float.TryParse(inputVal.text, out rpmVal))
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
    public void Reset()
    {
        niddle.gameObject.transform.rotation = originalPos;
        hours = minutes = seconds = timer = 0f;
        strHours = strMinutes = strSeconds = "00";
        rotationCount = 0;
        rotationCountHold = 0;
    }

    private void OnGUI()
    {
        hours = Mathf.Floor(timer/3600);
        minutes = (Mathf.Floor(timer / 60)) % 60;
        seconds = Mathf.Round(timer % 60);

        if (hours < 10f)
        {
            strHours = "0" + hours;
        }
        else
        {
            strHours = hours.ToString();
        }

        if (minutes < 10f)
        {
            strMinutes = "0" + minutes;
        }
        else
        {
            strMinutes = minutes.ToString();
        }

        if (seconds < 10f)
        {
            strSeconds = "0" + seconds;
        }
        else
        {
            strSeconds = seconds.ToString();
        }
        ////GUI.Label(new Rect(10,10,250,100), minutes + ":" + Mathf.RoundToInt(seconds));
        //output.text = minutes + ":" + Mathf.RoundToInt(seconds).ToString();

        diplayTimer.text = strHours + ":" + strMinutes + ":" + strSeconds;
        displayRotation.text = rotationCountHold.ToString();
    }
}
