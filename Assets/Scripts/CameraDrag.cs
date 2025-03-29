using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public float panSpeed = 40;
    public int camSpeed = -5;

    private Vector3 dragOrigin;
    private Vector3 cameraDragOrigin;

    void Update()
    {
       
        MouseInputs();
    }

    private void MoveCamera(float xInput, float zInput)
    {
        float zMove = Mathf.Cos(transform.eulerAngles.y * Mathf.PI / 180) * zInput - Mathf.Sin(transform.eulerAngles.y * Mathf.PI / 180) * xInput;
        float xMove = Mathf.Sin(transform.eulerAngles.y * Mathf.PI / 180) * zInput + Mathf.Cos(transform.eulerAngles.y * Mathf.PI / 180) * xInput;

        transform.position = transform.position + new Vector3(xMove, 0, zMove);
    }

    void MouseInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cameraDragOrigin = transform.position;
            dragOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition) - dragOrigin;
            Vector3 desirePos = cameraDragOrigin + camSpeed * new Vector3(pos.x, 0, pos.y) * panSpeed;
            Vector3 move = desirePos - transform.position;
            MoveCamera(move.x, move.z);
        }
    }
}
