using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;

    public void Interact() {
        Debug.Log("interact!");
        Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.perfab, counterTopPoint);
        kitchenObjectTransform.localPosition = Vector3.zero; //Generate object will go the same spot of the parent object.  

        Debug.Log(kitchenObjectTransform.GetComponent<KitchenObject>().GetKitchenObjectSO());
            
    }
}
