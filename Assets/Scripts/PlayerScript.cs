using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//General helpful stuff:
    //Logical operators for if-statements: 
        //use || for OR (If either statements is true, it will be true.)
        //use && for AND (statement is only true if ALL statements it is evaluating are true. Indeed, if either one doesn't, it won't work.)
        //use == for EQUAL TO (if the set values in de condition are the same, it is true. Otherwise it's false.)

public class PlayerScript : MonoBehaviour
{
    //General player related
    public static float moveForce = 5f;
    public int jumpForce;
    //Player Audio related
    public GameObject JumpAudioManager;

    private AudioManager jam;


    private float directionY;
    public int canDoubleJump = 0;
    float tempY = 0;

    //Shooter related
    public Rigidbody bullet;

    public Transform shooter;
    public Transform barrelEnd;
    //public Transform aimingTowards;

    public float fireRate = 0f;
    public float fireForce = 0f;
    private float fireRateTimeStamp = 0f;

    public Rigidbody rbody;

    //Camera related
    public Camera camera;
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public bool dashBool;
    
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("AudioManager") == null)
        {
            jam = Instantiate(JumpAudioManager).GetComponent<AudioManager>();
            Debug.Log("Audio for Jump was missing, instantiated one.");
        }

        rbody = GetComponent<Rigidbody>();
        camera = GetComponentInChildren<Camera>();
        
    }

    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            barrelEnd.transform.LookAt(raycastHit.point);
        }
        
        //barrelEnd.transform.LookAt(Input.mousePosition); //Geweer doet heel raar als dit aanstaat en gaat allerlei kanten op. Werkt soort van op een trippy manier, maar eigenlijk niet.

        if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump < 2)  //OLD VERSION: "rbody.AddForce(new Vector3(0, jumpForce, 0));"
        {
            jump();
            tempY = jumpForce;
        }

        /*
        //CODE FOR THE GUN.
        if (Input.GetKey(KeyCode.Q))
        {
            if (Time.time > fireRateTimeStamp)
            {
                GameObject go = (GameObject)Instantiate(bullet, shooter.position, shooter.rotation);
                go.GetComponent<Rigidbody>().AddForce(shooter.forward * fireForce);
                fireRateTimeStamp = Time.time + fireRate;
            }
        }*/

        
        //Alternate code for the gun, with a barrel in mind when aiming!
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Q)) //Input.GetKey(KeyCode.Q)
        {
            if (Time.time > fireRateTimeStamp)
            {
                //FindObjectOfType<AudioManager>().Play("TurretShot");

                Rigidbody bulletInstance;
                bulletInstance = Instantiate(bullet, barrelEnd.position, barrelEnd.rotation);
                bulletInstance.AddForce(barrelEnd.forward * fireForce);

                FindObjectOfType<AudioManager>().Play("GunShot");
                Debug.Log("Shooting Bullets, BOOM BOMB BOOM!");

                fireRateTimeStamp = Time.time + fireRate;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate() //FixedUpdate zorgt voor inconsistente jumps, waardoor de player soms later van de grond komt. Update is meer responsive, maar de player vibreert voordat hij de grond raakt.
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        
        if (dashBool == false)
        {
            transform.position += (transform.forward * vert + transform.right * hor).normalized * Time.deltaTime * moveForce;
            rbody.velocity = new Vector3(hor, directionY, vert);
        }



        //CAMERA WITH MOUSE CONTROLLED
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        transform.rotation = Quaternion.Euler(0.0f, yaw, 0.0f);
        camera.transform.localRotation = Quaternion.Euler(pitch, 0.0f, 0.0f);
             
        
        tempY -= -Physics.gravity.y * Time.deltaTime;
        directionY = tempY;
    }

    void jump()
    {
        jam.Play("PlayerJump");
        canDoubleJump++;
        //rbody.AddForce(this.gameObject.transform.up * jumpForce);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            FindObjectOfType<AudioManager>().Play("ImpactGround");
            canDoubleJump = 0;
        }
        
    }
}
