using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 offset;


    [SerializeField] public Text counterText;
    [SerializeField] public Text scoreText;
    
    [SerializeField] private int counter;
    [SerializeField] private int score;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        offset = transform.position - player.position;
    }

    
    void Update()
    {   
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + player.position.z);
            transform.position = newPosition;
        }
        else
        {
            return;
        }


        counter = ((int)(player.position.z / 2));
        counterText.text = ((int)(player.position.z / 2)).ToString();
        if(counter>score)
        {
            score = counter;
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.Save();
            scoreText.text = counter.ToString();       
        }
        score = PlayerPrefs.GetInt("Score", score);
        scoreText.text = score.ToString();


    }
}
