using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController _character;
    public float moveSpeed = 5.0f;
    public float turnSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        _character = GetComponent<CharacterController>();    
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(horizontal, 0, vertical);

        if (dir.magnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
        }

        _character.Move(dir.normalized * moveSpeed * Time.deltaTime);
    }
}
