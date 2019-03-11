using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector2 pos1;
    private Vector2 pos2;
    public Vector2 posDiff = new Vector2(0f, 20f);
    public float speed = 1.0f;

    void Start()
    {
        pos1 = (Vector2)transform.position;
        pos2 = (Vector2)transform.position + posDiff;
    }

    void Update()
    {
        transform.position = Vector2.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
