using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{   
    private Rigidbody _rb;
    private GameObject player;
    public Canvas _canvasButton;


    [SerializeField] private float speed;
    [SerializeField] private float deltaSpeed = 0.8f;
    [SerializeField] private float maxSpeed = 70f;
    public bool isDie;

    private int lineToMove = 1;
    public float lineDistance = 3; 

    void Start()
    {   
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();
        _canvasButton = GameObject.Find("CanvasButton").GetComponent<Canvas>();
        _canvasButton.gameObject.SetActive(false);
        _rb = GetComponent<Rigidbody>();
        isDie = false;
    }

    private void Update()
    {               
        if(!isDie){
            if (SwipeController.swipeRight)
            {
                if (lineToMove < 2)
                    lineToMove++;
            }

            if (SwipeController.swipeLeft)
            {
                if (lineToMove > 0)
                    lineToMove--;
            }

            Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
            if (lineToMove == 0)
                targetPosition += Vector3.left * lineDistance;
            else if (lineToMove == 2)
                targetPosition += Vector3.right * lineDistance;

            transform.position = targetPosition;
        }
    }

    void FixedUpdate()
    {
        if(!isDie){
            if(speed<maxSpeed)
            {
                speed += deltaSpeed * Time.deltaTime;
            }
            transform.Translate(0,0,speed*Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision other)
    {   
        if (other.gameObject.CompareTag("Cars"))
        {   
            _canvasButton.gameObject.SetActive(true);
            Debug.Log("Hit Something");
            this.enabled = false;
            
        }
    }
}