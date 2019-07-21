using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // take the current position and set to origin (0,0,0)
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // 1 unit is 1 meter ; new Vector3(1,0,0) * RealTime(deltaTime) * 5
        // use Time.deltaTime to run 1m/sec
        transform.Translate(Vector3.right * Time.deltaTime * 5);
    }
}
