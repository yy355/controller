using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private float distance;
    private float scrollSpeed = 10;
    private float rotateSpeed = 2;

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {

            transform.position = target.position + offset;
            transform.LookAt(target);
        }
        ScrollView();
        RotateView();
    }

    //视野拉近拉远
    void ScrollView()
    {
        distance = offset.magnitude;
        distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        distance = Mathf.Clamp(distance, 3, 18);
        offset = offset.normalized * distance;
    }

    //视野旋转
    void RotateView()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 originalPos = transform.position;
            Quaternion originalRot = transform.rotation;
            transform.RotateAround(target.position, target.up, Input.GetAxis("Mouse X") * rotateSpeed);
            transform.RotateAround(target.position, transform.right, Input.GetAxis("Mouse Y") * rotateSpeed);
            if (transform.eulerAngles.x < 5 || transform.eulerAngles.x > 60)
            {
                transform.position = originalPos;
                transform.rotation = originalRot;
            }

            offset = transform.position - target.position;
        }
    }
}
