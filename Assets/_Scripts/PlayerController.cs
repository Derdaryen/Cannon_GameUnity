using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Variables
    public int speed;
    public int friction;
    public int lernSpeed;
    float xDegrees;
    float yDegrees;
    Quaternion fromRotation;
    Quaternion toRotation;
    Camera _camera;


    private bool hasDisparin;


    public GameObject canonBall;
    public Slider slider;
    Rigidbody cannonBallRB;
    public Transform shotPosition;
    public ParticleSystem explotion;
    //[Range(500,15000)]
    private float firePawer;
    private int powerMultiplay = 4000;

    void Start()
    {
        _camera = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if(hit.transform.gameObject.tag == "Cannon")
            {
                if (Input.GetMouseButton(0))
                {
                    xDegrees -= Input.GetAxis("Mouse Y") * speed * friction;
                    yDegrees += Input.GetAxis("Mouse X") * speed * friction;
                    fromRotation = transform.rotation;
                    toRotation = Quaternion.Euler(xDegrees, yDegrees, 0);
                    transform.rotation = Quaternion.Lerp(fromRotation, toRotation,
                                    Time.deltaTime * lernSpeed);
                }
            }

        }

        /*if (Input.GetMouseButtonDown(1))
        {
            FireCannon();
        }*/

      
        
    }


    public void FireCannon()
    {

        /*if (hasDisparin == true)
        {
            explotion.Play();
        }
        else
        {
            explotion.Stop();
        }*/
        firePawer = slider.value * powerMultiplay;
        shotPosition.rotation = transform.rotation;
        GameObject CannonBallCopy = Instantiate(canonBall, shotPosition.position,
            transform.rotation) as GameObject;
        cannonBallRB = CannonBallCopy.GetComponent<Rigidbody>();
        cannonBallRB.AddForce(transform.up * firePawer);
        Instantiate(explotion, shotPosition.position, shotPosition.rotation);
        explotion.Stop();
    }
}
