using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class MyController2 : MonoBehaviour {

    public GameObject mustache, leftEyeBrow, rightEyeBrow;
    public GameObject sensor, metal;
    public GameObject eyes;
    //public GameObject leftBrowUpStroke, leftBrowDownStroke, rightBrowUpStroke, rightBrowDownStoke, mustacheUpStroke, mustacheDownStroke, eyeLeftStroke, eyeRightStroke;
    //public GameObject leftEye, rightEye;
    public float distance;

    public float speed;

    private float amountToMove;
    private string mustacheState, leftEyeBrowState, rightEyeBrowState, eyesState;
    private int sensorState;

    SerialPort sp = new SerialPort("COM7", 9600);

    private void Start()
    {
        if (!sp.IsOpen)
        {
            sp.Open();
        }
        speed = 1;
    }

    // Update is called once per frame
    void Update () {
        amountToMove = speed * Time.deltaTime;
        AssignValue();
        MoveMustache(mustacheState);
        //MoveLeftEyeBrow(leftEyeBrowState);
        //MoveRightEyeBrow(rightEyeBrowState);
        //MoveEyes(eyesState);
        Sense();
    }

    void MoveMustache(string direction) {
        if (direction == "m1") {
                mustache.gameObject.transform.Translate(Vector3.up * amountToMove, Space.World);
        }
        if (direction == "m0") {
                mustache.gameObject.transform.Translate(Vector3.down * amountToMove, Space.World);
        }
        Debug.Log(direction);
    }

    /*void MoveLeftEyeBrow(string direction)
    {
        if (direction == "l1")
        {
            float lUpStroke = Vector3.Distance(leftEyeBrow.transform.position, leftBrowUpStroke.transform.position);
            if (lUpStroke > 0.03f) {
                leftEyeBrow.gameObject.transform.Translate(Vector3.up * amountToMove, Space.World);
            }
                
        }
        if (direction == "l0")
        {
            float lDownStroke = Vector3.Distance(leftEyeBrow.transform.position, leftBrowDownStroke.transform.position);
            if (lDownStroke > 0.03f){
                leftEyeBrow.gameObject.transform.Translate(Vector3.down * amountToMove, Space.World);
            }
                
        }
    }

    void MoveRightEyeBrow(string direction)
    {
        if (direction == "r1")
        {
            float rUpStroke = Vector3.Distance(rightEyeBrow.transform.position, rightBrowUpStroke.transform.position);
            if (rUpStroke > 0.03f){
                rightEyeBrow.gameObject.transform.Translate(Vector3.up * amountToMove, Space.World);
            }    
        }
        if (direction == "r0")
        {
            float rDownStroke = Vector3.Distance(rightEyeBrow.transform.position, rightBrowDownStoke.transform.position);
            if (rDownStroke > 0.03f){
                rightEyeBrow.gameObject.transform.Translate(Vector3.down * amountToMove, Space.World);
            }   
        }
    }

    void MoveEyes(string direction)
    {
        if (direction == "e1")
        {
            float eLeftStroke = Vector3.Distance(leftEye.transform.position, eyeLeftStroke.transform.position);
            if (eLeftStroke > 0.03f){
                eyes.gameObject.transform.Translate(Vector3.left * amountToMove, Space.World);
            }   
        }
        if (direction == "e0")
        {
            float eRightStroke = Vector3.Distance(rightEye.transform.position, eyeRightStroke.transform.position);
            if (eRightStroke > 0.03f){
                eyes.gameObject.transform.Translate(Vector3.right * amountToMove, Space.World);
            }   
        }
    }*/

    void AssignValue() {
        switch (sp.ReadLine().ToString()) {
            case "l1":
                leftEyeBrowState = "l1";
                break;
            case "l0":
                leftEyeBrowState = "l0";
                break;
            case "r1":
                rightEyeBrowState = "r1";
                break;
            case "r0":
                rightEyeBrowState = "r0";
                break;
            case "m1":
                mustacheState = "m1";
                break;
            case "m0":
                mustacheState = "m0";
                break;
            case "e1":
                eyesState = "e1";
                break;
            case "e0":
                eyesState = "e0";
                break;
        }
    }
    void Sense() {
        distance = Vector3.Distance(sensor.transform.position, metal.transform.position);
        if (distance <= 1f)
        {
            sensorState = 1;
            sp.WriteLine("1");
            Debug.Log("on");
        }
        else {
            sensorState = 0;
            sp.WriteLine("0");
            Debug.Log("off");
        }
    }
}
