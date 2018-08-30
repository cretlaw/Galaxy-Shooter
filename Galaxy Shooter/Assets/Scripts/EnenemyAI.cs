using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenemyAI : MonoBehaviour
{

    [SerializeField] private float _speed = 3.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -5.9f)
        {
            transform.position = new Vector3(Random.Range(-8.2f, 8.2f), 4.12f, 0);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            if(other.transform.parent != null)
                Destroy(other.transform.parent.gameObject);

            Destroy(other.gameObject);
            
        }
        else if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if(player != null)
                player.Damage();
        }

        Destroy(this.gameObject);
    }
}
