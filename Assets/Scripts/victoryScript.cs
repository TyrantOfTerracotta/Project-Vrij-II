using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class victoryScript : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //FindObjectOfType<AudioManager>().Play("Victory");
            SceneManager.LoadScene("Victory");            
            Debug.Log("Well done!");
            //Destroy(gameObject);
        }
    }
}
