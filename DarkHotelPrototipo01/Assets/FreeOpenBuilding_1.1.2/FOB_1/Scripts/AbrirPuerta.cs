using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuerta : MonoBehaviour
{
    /*public float speed;
    public float angle;
    public Vector3 direction;

    public bool puedeAbrir;
    // Start is called before the first frame update
    void Start()
    {
        angle = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Round(transform.eulerAngles.y) != angle){
            transform.Rotate(direction * speed);
        }
        if(Input.GetButtonDown("Fire1") && puedeAbrir == true){
            angle=90;
            direction = Vector3.up;
        }else if(){

        }
    }

    void OnTriggerStay(Collider other){
        if(other.gameObject.tag == "Player"){
            puedeAbrir = true;
        }
    }
    void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Player"){
            puedeAbrir = false;
        }
    }*/

    public float speed;
    public float openAngle = 90.0f;
    public float closedAngle;
    public Vector3 direction;

    private bool puedeAbrir;
    private bool isOpen = false;

    void Start()
    {
        closedAngle = transform.eulerAngles.y;
    }

    void Update()
    {
        float targetAngle = isOpen ? openAngle : closedAngle;

        if (Mathf.Round(transform.eulerAngles.y) != targetAngle)
        {
            float step = speed * Time.deltaTime;
            Vector3 newRotation = Vector3.up * step;
            transform.Rotate(newRotation * direction.y);
        }

        if (Input.GetButtonDown("Fire1") && puedeAbrir)
        {
            isOpen = !isOpen;
            direction = isOpen ? Vector3.up : Vector3.down; // Cambia la dirección dependiendo del estado
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            puedeAbrir = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            puedeAbrir = false;
        }
    }
}
