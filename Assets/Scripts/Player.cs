using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float rotateSpeed = 10f;

    [SerializeField] private GameInput gameInput;

    private bool isWalking;

    private void Update() {
        Vector2 inputVector = gameInput.GetMovementVectorNormlized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);


        float playerRadius = 0.65f;
        float playerHeight = 1.4f;
        Vector3 capsultStart = transform.position;
        Vector3 capsultEnd = capsultStart + Vector3.up * playerHeight;
        float moveDistance = moveSpeed * Time.deltaTime;


        // oneline RayCast can't detect precisely, using other shape to better perform it.
        bool canMove = !Physics.CapsuleCast(capsultStart, capsultEnd, playerRadius, moveDir, moveDistance);

        if (!canMove) {
            //Cannot move towards moveDir

            //Attempt only X movement
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0);
            canMove = !Physics.CapsuleCast(transform.position, capsultEnd, playerRadius, moveDirX, moveDistance);

            if (canMove)
            {
                moveDir = moveDirX;
            } else {
                //Attempt only Z movement
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z);
                canMove = !Physics.CapsuleCast(transform.position, capsultEnd, playerRadius, moveDirZ, moveDistance);

                if (canMove) {
                    moveDir = moveDirZ;
                } else {
                    //Cannot move in any direction
                    canMove = false;
                }
            }
        }

        if (canMove) {
            transform.position += moveDir * moveDistance;
        }

        isWalking = (moveDir != Vector3.zero); 
        //Way to look at one side
        //transform.forward = moveDir; //method 1 not rotate smoothly

        //Move more smoothly
        //Tips: if we don't press button, moveDir is (0,0,0), is not a valid value.
        //      So player won't keep rotate unless we press other direction.
        //      transform.forward similar to moveDir: is Vector3(0,0,0) value 0-1
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);

    }

    public bool IsWalking() {
        return isWalking;
    }
}
