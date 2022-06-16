using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class missileButtonScript : MonoBehaviour
{
    //public GameObject goldRespawnPoint;
    //public GameObject Player;



    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "JadeMissile")
        {
            FindObjectOfType<AudioManager>().Play("WrongAnswer");

            //Player.transform.position = goldRespawnPoint.transform.position;
            //SceneManager.LoadScene("Defeat");            
            Debug.Log("Could it be this one?!");
            Destroy(gameObject);
        }
    }
}
