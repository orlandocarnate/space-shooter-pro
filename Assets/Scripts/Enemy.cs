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
        transform.position = new Vector3(Random.Range(-11f, 11f), 7, 0);
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

    void OnTriggerEnter(Collider other)
    {
        // if other is player -> Destroy us && Damage Player
        // if other is laser -> destroy us
        switch (other.tag)
        {
            case "Player":
                Destroy(this.gameObject);
                break;

            case "Laser":
                Destroy(this.gameObject);
                Destroy(other.gameObject);
                break;
        }

    }

}
