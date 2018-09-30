using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {
    public GameObject firstSide , secondSide;
    public Vector3 movedPositionA , movedPositionB;
    Vector3 originalA, originalB;
    public float moveSpeed = 200f;

	void Start () {
        originalA = firstSide.transform.position;
        originalB = secondSide.transform.position;
	}
	
    void OnTriggerEnter (Collider col) {
        if(col.gameObject.CompareTag("Gate"))
        {
            firstSide.transform.position = Vector3.Lerp(firstSide.transform.position,movedPositionA,moveSpeed *Time.deltaTime);
            secondSide.transform.position = Vector3.Lerp(secondSide.transform.position, movedPositionB, moveSpeed * Time.deltaTime);
            print("inside");
            //open door if inside set area
        }
	}
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Gate"))
        {
            firstSide.transform.position = Vector3.Lerp(firstSide.transform.position, originalA, moveSpeed * Time.deltaTime);
            secondSide.transform.position = Vector3.Lerp(secondSide.transform.position, originalB, moveSpeed * Time.deltaTime);
            print("outside");
        }
    }
}
