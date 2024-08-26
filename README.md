# KitchenChaos

## Raycast (Collision Detection部分)

### Gizmos 用於 Debug raycast，但是實際的線要通過其他程式來完成
```csharp
    bool canMove = !Physics.CapsuleCast(capsultStart, capsultEnd, playerRadius, moveDir, moveDistance);
    //Physics.CapsuleCast 畫一個膠囊體
```

### 兩種較簡單的Debug raycast方式：
```csharp
    Debug.DrawRay(transform.position, moveDir * playerRadius, Color.red);
```
#### Debug.DrawRay 用途: 用於從某個起點開始沿著指定方向繪製一條射線。
+ start: 射線的起點 (Vector3)。
+ dir: 射線的方向和長度 (Vector3)。
+ color (可選): 射線的顏色 (Color)。
+ duration (可選): 射線存在的時間，默認為一幀。
+ depthTest (可選): 決定射線是否應該受深度測試影響，默認為 true。

使用情境: 當你想要從某一個點出發，沿著某個方向繪製射線時，DrawRay 非常有用。這在調試 Raycast 或 Physics Raycast 時特別有幫助，因為你可以可視化射線的路徑。

```csharp
Debug.DrawLine(transform.position, moveDir * playerRadius, Color.red);
```

#### Debug.DrawLine 用途: 用於在兩個指定的點之間繪製一條直線。
+ start: 線段的起點 (Vector3)。
+ end: 線段的終點 (Vector3)。
+ color (可選): 線段的顏色 (Color)。
+ duration (可選): 線段存在的時間，默認為一幀。
+ depthTest (可選): 決定線條是否應該受深度測試影響（即它是否會被遮擋住），默認為 true。

**使用情境: 當你需要在兩個確定的點之間繪製一條直線時，例如，想要在場景中顯示兩個物件之間的連接線。**
```csharp
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
```