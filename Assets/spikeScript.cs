using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spikeScript : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //FindObjectOfType<AudioManager>().Play("PlayerDeath");
            SceneManager.LoadScene("Defeat");            
            Debug.Log("The skull ate your soul!");
            Destroy(gameObject);
        }
    }
}
