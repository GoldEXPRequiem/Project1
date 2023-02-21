using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SphereMove : MonoBehaviour
{
    public int score=0;
    public TMP_Text scoreTest; 
    public GameObject pauseObject; 
    private bool countdown;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        score=0;
        countdown=false;
        timer=0;
    }

    // Update is called once per frame
    void Update()
    {
        float speed=10 * Time.deltaTime;
        /*
        float speed=0.5f;
        if (Input.GetKey(KeyCode.UpArrow))
            transform.position += new Vector3(0,0,speed);
        if(Input.GetKey(KeyCode.DownArrow))
            transform.position -= new Vector3(0,0,speed);
        if(Input.GetKey(KeyCode.LeftArrow))
           transform.position -=new Vector3(speed,0,0);
        if(Input.GetKey(KeyCode.RightArrow))
           transform.position +=new Vector3(speed,0,0);
        */
        
        float horizMove= Input.GetAxisRaw("Horizontal");
        float Zmove= Input.GetAxisRaw("Vertical");

         Vector3 Movement= new Vector3(horizMove,0,Zmove)* speed;
        transform.position += Movement;

        if(Input.GetKeyDown(KeyCode.Space)){
            if(Time.timeScale == 0){
                Time.timeScale=1;
                pauseObject.SetActive(false);
            }
            else{
                Time.timeScale=0;
                pauseObject.SetActive(true);
            }
        }

        if(Input.GetKeyDown(KeyCode.Q)){
            if(countdown){
                if(timer<3){
                    timer +=Time.deltaTime;
                } else{
                    UnityEditor.EditorApplication.isPlaying=false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Trigger entered");
        float newX = Random.Range(-11, 11);
        float newZ = Random.Range(-5, 5);
        other.transform.position = new Vector3(newX, 0, newZ);
        score++;
        Debug.Log("Score is now: "+score);
        scoreTest.text="Score: "+score;
    }
    private void OnTriggerStay(Collider other){
        Debug.Log("Still in the Trigger");
    }

    private void OnTriggerExit(Collider other){
            Debug.Log("Exited the Trigger");
    }
}
