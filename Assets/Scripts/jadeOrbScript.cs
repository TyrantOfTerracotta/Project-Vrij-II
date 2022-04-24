using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jadeOrbScript : MonoBehaviour
{
    public GameObject jadeOrb;
    public GameObject jadeHoldingCell;

    //public Transform jadeOrbSpawnPoint;



    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "JadeMissile")
        {
            FindObjectOfType<AudioManager>().Play("UnlockSecret");
            //GameObject jadeOrb;
            //Instantiate(jadeOrb, jadeOrbSpawnPoint.position, jadeOrbSpawnPoint.rotation);
            //Player.transform.position = goldRespawnPoint.transform.position;
            //SceneManager.LoadScene("Defeat");            
            Debug.Log("Ohhh?! A shining green orb!");
            Destroy(jadeHoldingCell.gameObject);
        }
    }
}
