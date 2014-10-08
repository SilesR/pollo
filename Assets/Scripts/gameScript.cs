using UnityEngine;
using System.Collections;

public class gameScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
						Reiniciar ();
				}
	
	}
	public void Salir1(){
		Application.Quit ();
		}
	public void Reiniciar(){
		Application.LoadLevel ("menu");
		}
	public void Iniciar(){
		Application.LoadLevel ("Pollo");
		}
}
