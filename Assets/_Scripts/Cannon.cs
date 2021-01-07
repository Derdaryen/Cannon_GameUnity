using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
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
            if (hit.transform.gameObject.tag == "Cannon")
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




    }
 
    }
