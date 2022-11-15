using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class ship_script : MonoBehaviour
{
    public float speed = 5, acceleration = 2;
    public Vector2 screenSize, shipSize;
    public TextMeshProUGUI infoText;
    public float angle;



    private void Start()
    {
        InitializeSizes();
    }

    public void Update()
    {
        Vector2 mouse = Input.mousePosition;
        Vector3 screenpoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        Vector3 offset = new Vector2(mouse.x - screenpoint.x, mouse.y - screenpoint.y);
        angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        

        if (Input.GetKey(KeyCode.Space) && speed <= 11)
        {
            speed += acceleration * Time.deltaTime;
        }
        if (!Input.GetKey(KeyCode.Space) && speed > 6)
        {
            speed -= acceleration * Time.deltaTime;
        }
        // Gauche ---> Droite
        if (transform.position.x >= screenSize.x / 2 + shipSize.x / 2)
        {
            transform.position = new Vector3(-screenSize.x / 2 - shipSize.x / 2, transform.position.y);
        }
        transform.position += transform.right * speed * Time.deltaTime;

        // Bas ---> Haut
        if (transform.position.y >= screenSize.y / 2 + shipSize.y / 2)
        {
            transform.position = new Vector3(transform.position.x, -screenSize.y / 2 - shipSize.y / 2);
        }
        // Droite ---> Gauche
        if (transform.position.x < -screenSize.x / 2 - shipSize.x / 2)
        {
            transform.position = new Vector3( screenSize.x / 2 + shipSize.x / 2, transform.position.y);
        }
        // Haut ---> Bas
        if (transform.position.y < -screenSize.y / 2 - shipSize.y / 2)
        {
            transform.position = new Vector3(transform.position.x, screenSize.y / 2 + shipSize.y / 2);
        }
        //infoText.text = "Acceleration : " + acceleration + " ; Speed : " + speed + " :)";
        infoText.text = string.Format("{0:00}:{1:00}", Time.timeSinceLevelLoad / 60, Time.timeSinceLevelLoad % 60);
        infoText.text += $"\nAcceleration :  {acceleration}   ; Speed :  {(int)speed}  :)";
        //infoText.text = string.Format("Acceleration :  + {0} +  ; Speed :  + {1} +  :)", acceleration, speed);

        
    }

    void InitializeSizes()
    {
        screenSize = Camera.main.ViewportToWorldPoint(Vector2.one) - Camera.main.ViewportToWorldPoint(Vector2.zero);
        shipSize = GetComponent<SpriteRenderer>().bounds.size;
    }
}