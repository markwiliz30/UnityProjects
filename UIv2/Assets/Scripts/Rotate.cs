using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour {

    public float speed = 5f;

    private void Update()
    {
        transform.Rotate(new Vector3(0,0,(Time.deltaTime * 6))*-1);
    }
}
