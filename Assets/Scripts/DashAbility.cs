using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : MonoBehaviour
{


    [SerializeField] private Rigidbody rbody;
    
    public float dashSpeed;
    public float dashTime;
    public float dashModifier;

    private float lastClickTime;

    [SerializeField] private const float double_click_time = .2f;


    
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            float timeSinceLastClick = Time.time - lastClickTime;

            if (timeSinceLastClick <= double_click_time)
            {
                //double click***
                Debug.Log("Double Clicked Successfully");
                
                StartCoroutine(Dash());
            }
            else
            {
                //normal click***
            }

            lastClickTime = Time.time;
        }
    }


    IEnumerator Dash()
    {
        rbody.gameObject.GetComponent<PlayerScript>().dashBool = true;

        rbody.AddForce(Camera.main.transform.forward * (dashSpeed * dashModifier) * Time.deltaTime);
        FindObjectOfType<AudioManager>().Play("PlayerDash");
        //rbody.velocity = (Camera.main.transform.forward * dashSpeed);

        yield return new WaitForSeconds(dashTime);
        rbody.gameObject.GetComponent<PlayerScript>().dashBool = false;
        //removes velocity after the dash***
        rbody.velocity = Vector3.zero;
        
    }


}
