using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    public GameObject target;
    public float speed = 6, stepModifier = 0.2f;
    float step;

    void Start()
    {

    }

    void Update()
    {
        // TODO random target every x amount of time

        // Rotate towards destination
        Vector3 targetDir = target.transform.position - transform.position;
        step = stepModifier * Time.deltaTime * speed * 2;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);

        // Move forward
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
