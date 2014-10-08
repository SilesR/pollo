using UnityEngine;
using System.Collections;

public class siguienteNivel : MonoBehaviour {

	// Use this for initialization
		void OnTriggerEnter2D(Collider2D other){
			Siguiente();
		}

	public void Siguiente(){
		Application.LoadLevel ("Pollo2");
	}
}
