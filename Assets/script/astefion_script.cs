using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class astefion_script : MonoBehaviour
{
    public float speed = 5;
    public Vector2 screenSize, astefionSize;



    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
        InitializeSizes();

    }

    public void Update()
    {




        // Gauche ---> Droite
        if (transform.position.x >= screenSize.x / 2 + astefionSize.x / 2)
        {
            transform.position = new Vector3(-screenSize.x / 2 - astefionSize.x / 2, transform.position.y);
        }
        transform.position += transform.right * speed * Time.deltaTime;

        // Bas ---> Haut
        if (transform.position.y >= screenSize.y / 2 + astefionSize.y / 2)
        {
            transform.position = new Vector3(transform.position.x, -screenSize.y / 2 - astefionSize.y / 2);
        }
        // Droite ---> Gauche
        if (transform.position.x < -screenSize.x / 2 - astefionSize.x / 2)
        {
            transform.position = new Vector3(screenSize.x / 2 + astefionSize.x / 2, transform.position.y);
        }
        // Haut ---> Bas
        if (transform.position.y < -screenSize.y / 2 - astefionSize.y / 2)
        {
            transform.position = new Vector3(transform.position.x, screenSize.y / 2 + astefionSize.y / 2);
        }

    }

    void InitializeSizes()
    {
        screenSize = Camera.main.ViewportToWorldPoint(Vector2.one) - Camera.main.ViewportToWorldPoint(Vector2.zero);
        astefionSize = GetComponent<SpriteRenderer>().bounds.size;

    }

}
