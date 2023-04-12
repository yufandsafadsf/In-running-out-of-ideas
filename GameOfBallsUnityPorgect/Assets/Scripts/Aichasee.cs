using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aichasee : MonoBehaviour
{
    private Rigidbody2D Chaser;
    public float speed;

    private float distance;

    void Update()
    {
        distance = Vector2.Distance(transform.position, Chaser.transform.position);
        Vector2 direction = Chaser.transform.position - transform.position;


        transform.position = Vector2.MoveTowards(this.transform.position, Chaser.transform.position, speed * Time.deltaTime);
    }
}