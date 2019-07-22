using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // public or private reference
    // data type (int, float, bool, string)
    // every variable has a name
    // optional: assigned value

    [SerializeField]
    private float _speed = 3.5f; // default is 0 if unassigned. 'f' is required for floats
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;


    // Start is called before the first frame update
    void Start()
    {
        // take the current position and set to origin (0,0,0)
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement(); // call custom method

        // add a Cool Down period
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
    }

    // custom method
    void CalculateMovement()
    {
        float horizInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 1 unit is 1 meter ; new Vector3(1,0,0) * RealTime(deltaTime) * 5
 

        Vector3 direction = new Vector3(horizInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        // set boundaries
        /*
        if (transform.position.y >= 6)
        {
            transform.position = new Vector3(transform.position.x, 6, 0);
        }
        else if (transform.position.y <= -6)
        {
            transform.position = new Vector3(transform.position.x, -6, 0);
        }
        */
        // optimized code using Mathf.Clamp eliminating need for if else
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -6, 6), 0);

        // wrap X axis
        if (transform.position.x >= 11)
        {
            transform.position = new Vector3(-11, transform.position.y, 0);
        }
        else if (transform.position.x <= -11)
        {
            transform.position = new Vector3(11, transform.position.y, 0);
        }

        

    }

    void FireLaser()
    {
        // if we hit space key, spawn a laser gameObject
            _canFire = Time.time + _fireRate;
            Instantiate(_laserPrefab, transform.position + (new Vector3(0, 0.8f, 0)), Quaternion.identity);
    }

    public void Damage()
    {
        _lives--;

        if (_lives < 1)
        {
            Destroy(this.gameObject);
        }
    }

}
