using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player_controller : MonoBehaviour {

    // Use this for initialization
    ParticleSystem smokestop;
    private CharacterController charController;
    public Image pollBar;
    public Image TimeBar;

    public float timeLeft;
    public bool moretrash=true;
    public float movementSpeed = 3.1f;
    public float gravity = 9.814f;
    public float rotationSpeed = 1f;
    public float rotate_degreePerSecond = 1f;
    public float pollution=10f;
    public float pollution_max= 20f;
    public GameObject collectedTrash;
    public float pollutionOnMovement= 0.002f;
    public float trashPollution=1.0f;
    public int total_Existing=0 ;
    float onrun=0.0f;
    int collected;

    // Use this for initialization
    void Awake()
    {
        charController = GetComponent<CharacterController>();
        smokestop = GameObject.Find("Smoke").GetComponent<ParticleSystem>();
        pollBar = GameObject.FindGameObjectWithTag("pollution").GetComponent<Image>();
        TimeBar = GameObject.FindGameObjectWithTag("time").GetComponent<Image>();
        collectedTrash = GameObject.FindGameObjectWithTag("trashCollected");
    }

    // Update is called once per frame
    void FixedUpdate(){
        move();
        rotate();
        pollBar.fillAmount = ( pollution) / 100.0f;
        TimeBar.fillAmount = (timeLeft)/100.0f;
        timeLeft -= Time.deltaTime;
        collectedTrash.GetComponent<Text>().text = "" + collected;
        var emi = smokestop.emission;
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0) emi.enabled = false;
        else emi.enabled = true;

    }


    void move()
    {
        if (Input.GetAxis("Vertical") > 0){
            Vector3 moveDirection = transform.forward;
            //moveDirection.y -= gravity * Time.fixedDeltaTime;
            charController.Move(moveDirection * movementSpeed * Time.fixedDeltaTime);
            pollution += pollutionOnMovement;
        }
        else if (Input.GetAxis("Vertical") < 0){
            Vector3 moveDirection = -transform.forward;
            //moveDirection.y -= gravity * Time.fixedDeltaTime;
            charController.Move(moveDirection * movementSpeed * Time.fixedDeltaTime);
            pollution += pollutionOnMovement;
        }
        else{ 
            charController.Move(Vector3.zero);
            pollution -= pollutionOnMovement;
            Debug.Log("Stoped");
        }
     }


    void rotate()
    {
        pollution += pollutionOnMovement;
        Vector3 rotation_Direction = Vector3.zero;
        if (Input.GetAxis("Horizontal") < 0){
                rotation_Direction = transform.TransformDirection(Vector3.left);
                pollution += pollutionOnMovement;
        }
        else if (Input.GetAxis("Horizontal") > 0){
                rotation_Direction = transform.TransformDirection(Vector3.right);
                pollution += pollutionOnMovement;
        }
        if (rotation_Direction != Vector3.zero){
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(rotation_Direction), rotate_degreePerSecond * Time.fixedDeltaTime);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("garbage")) {
            Destroy(other.gameObject);
            collected += 1;
            total_Existing -= 1;
            pollution -= 2*trashPollution;
        }
    }
}

