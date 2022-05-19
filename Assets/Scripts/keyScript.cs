using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keyScript : MonoBehaviour
{
    [SerializeField] public GameObject barrier;
    [SerializeField] public GameObject gateOrb;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Key")
        {
            //FindObjectOfType<AudioManager>().Play("KeyFound");
            Debug.Log("The door got unlocked!");
            Destroy(barrier.gameObject);
            //Destroy(gateOrb.gameObject);
            //Destroy(this.gameObject);
        }
    }
}
