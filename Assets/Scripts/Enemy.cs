using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move down 4m/s
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        // if exits bottom of screen, respawn at top with new random x position
        if (transform.position.y < -7)
        {
            float randomX = Random.Range(-11f, 11f);
            transform.position = new Vector3(randomX, 7, 0);
        } 

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            
            if (other.transform.GetComponent<Player>() != null)
            {
                other.transform.GetComponent<Player>().Damage();
            }
        }

        if (other.tag == "Laser")
        { 
                Destroy(this.gameObject);
                Destroy(other.gameObject);
        }

    }

}
