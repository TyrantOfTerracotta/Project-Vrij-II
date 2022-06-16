using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    public GameObject objToFollow;
    public float speed = 5f;

    void Update()
    {
        transform.LookAt(objToFollow.transform.position);

        if (Vector3.Distance(transform.position, objToFollow.transform.position) > .5f)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
