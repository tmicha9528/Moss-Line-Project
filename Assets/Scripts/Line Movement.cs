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
    public GameObject cameraObj;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    ball.transform.position = new Vector3(0, 0, 0);
    //    ball_line.transform.position = new Vector3(0, 0, 0);
    //}

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0) { PerformBallAndLineMove(GetTouchPosition(Input.GetTouch(0).position)); }
        if (Input.GetMouseButton(0)) { PerformBallAndLineMove(GetTouchPosition(Input.mousePosition)); }
    }

    Vector3 GetTouchPosition (Vector3 inputPosition)
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera
        Ray camRay = Camera.main.ScreenPointToRay(inputPosition);
        // Create a RaycastHit variable to store information about what was hit by the ray
        RaycastHit hit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out hit))
        {
            // Create a vector at the point where the raycast hit the floor
            Vector3 spawnPoint = hit.point;
            return spawnPoint;
            // Spawn the prefab at the location of the hit point
        }
        return Vector3.zero;
    }

    void PerformBallAndLineMove(Vector3 posOfTouch)
    {
        ball.transform.position = new Vector3(posOfTouch.x, ball.transform.position.y, posOfTouch.z);
        var ballXPosition = ball.transform.localPosition.x;
        print(ballXPosition);
        float mossFormulaForBackLinePosX = ballXPosition * 0.085f + 85.8f;
        float backLineAdjustedForFieldPerspective = mossFormulaForBackLinePosX - 105f;
        back_line.transform.position = new Vector3(backLineAdjustedForFieldPerspective, back_line.transform.position.y, back_line.transform.position.z);
    }
}
