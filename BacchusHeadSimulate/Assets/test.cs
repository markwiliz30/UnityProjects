using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class test : MonoBehaviour {

    public float speed;

    private float amountToMove;

    SerialPort sp = new SerialPort("COM7", 9600);

    // Use this for initialization
    void Start () {
        speed = 1;
    }
	
	// Update is called once per frame
	void Update () {
        amountToMove = speed * Time.deltaTime;
        MoveObject(sp.ReadLine().ToString());
    }

    void MoveObject(string direction)
    {
        if (direction == "1")
        {
            transform.Translate(Vector3.up * amountToMove, Space.World);
        }
        if (direction == "0")
        {
            transform.Translate(Vector3.down * amountToMove, Space.World);
        }
    }
}
