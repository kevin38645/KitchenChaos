# KitchenChaos

## Raycast (Collision Detection部分)

Gizmos 用於 Debug raycast，但是實際的線要通過其他程式來完成

    bool canMove = !Physics.CapsuleCast(capsultStart, capsultEnd, playerRadius, moveDir, moveDistance);
    //Physics.CapsuleCast 畫一個膠囊體

    /* 兩種較簡單的Debug raycast方式*/
    //Debug.DrawRay(transform.position, moveDir * playerRadius, Color.red);
    //Debug.DrawLine(transform.position, moveDir * playerRadius, Color.red);

    /*  Gizmos debug raycast方式*/
    void OnDrawGizmos() {
        //寫在C#檔案編譯完就可以直接看到debug的線了
        Gizmos.color = Color.blue;
        float playerRadius = 0.65f;
        float playerHeight = 1.4f;
        Vector3 capsuleStart = transform.position;
        Vector3 capsuleEnd = capsuleStart + Vector3.up * playerHeight;
        float moveDistance = moveSpeed * Time.deltaTime;

        //膠囊體的繪畫並沒有直接的方法，可以用兩個圓體表示頂部和底部，中間的部分會是長方形
        Gizmos.DrawWireSphere(capsuleStart, playerRadius);  // 繪製膠囊體的底部
        Gizmos.DrawWireSphere(capsuleEnd, playerRadius);  // 繪製膠囊體的頂部
    }