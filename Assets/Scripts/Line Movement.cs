using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;

public class LineMovement : MonoBehaviour
{
    public GameObject ball;
    public GameObject ball_line;
    public GameObject back_line;

    // Start is called before the first frame update
    void Start()
    {
        ball.transform.position = new Vector3(0, 0, 0);
        ball_line.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
