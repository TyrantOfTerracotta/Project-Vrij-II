using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileFieldScript : MonoBehaviour
{

    public Rigidbody bullet;
    public Transform barrelEnd;
    public Transform aimingTowards;
    
    public float fireForce;
    public float lifeTimeBullet;
    public float canFire;
 

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            Debug.Log("Firing a missile!");
            canFire = 1.0f;

            FindObjectOfType<AudioManager>().Play("ActivateMine");

            //Destroy(obstacle.gameObject);

            
        }
    }


    void Update()
    {
        barrelEnd.transform.LookAt(aimingTowards);

            if (canFire == 1.0f)
            {
                FindObjectOfType<AudioManager>().Play("LaunchMissile");

                //Shooting
                Rigidbody bulletInstance;
                bulletInstance = Instantiate(bullet, barrelEnd.position, barrelEnd.rotation);
                bulletInstance.AddForce(barrelEnd.forward * fireForce);
                Destroy(bulletInstance.gameObject, lifeTimeBullet);

                canFire = 0f;
            }
    }
}
