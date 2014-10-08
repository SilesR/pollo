using UnityEngine;
using System.Collections;

public class bombaScript : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("Se ha chocado contra la bomba");
		}
}
