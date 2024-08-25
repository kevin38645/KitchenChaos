using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float rotateSpeed = 10f;

    private void Update() {
        Vector2 inputVector = new Vector2(0, 0);
        if(Input.GetKey(KeyCode.W)) {
            inputVector.y = 1;
        }
        if (Input.GetKey(KeyCode.S)) {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A)) {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D)) {
            inputVector.x = +1;
        }
        inputVector = inputVector.normalized;
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        //Way to look at one side
        //transform.forward = moveDir; //method 1 not rotate smoothly

        //Move more smoothly
        //Tips: if we don't press button, moveDir is (0,0,0), is not a valid value.
        //      So player won't keep rotate unless we press other direction.
        //      transform.forward similar to moveDir: is Vector3(0,0,0) value 0-1
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);

    }
}
