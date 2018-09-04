using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;

    [SerializeField] private int powerupId;
    [SerializeField] private AudioClip _clip;
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -8.2)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Enable triple Shot
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                if (powerupId == 0)
                    player.TriplePowerShotOn();
                else if (powerupId == 1)
                    player.HyperSpeedOn();
                else if (powerupId == 2)
                    player.ShieldOn();
            }

            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1.0f);
            //Destroy powerup
            Destroy(this.gameObject);
        }

    }
}
