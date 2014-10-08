using UnityEngine;
using System.Collections;

public class jumpScript : MonoBehaviour {
	public int jumpForce = 200;//Fuerza de salto
	private int lateralForce = 50;//Fuerza de movimiento horizontal al mover
	public int maxSpeed = 20;//velocidad maxima horizontal
	public AudioClip sonidoVolar;
	public AudioClip sonidohHerido;
	public AudioClip sonidoCurado;//TODO falta tal
	public AudioClip sonidoChoque;
	private bool herido = false;//para saber cuando el pollo esta herido o no.


	//Esto es para poder manejar las animaciones
	Animator animation;

	void Start(){
		//al inicializar cargamos las variables de las animaciones
				animation = GetComponent <Animator> ();
		}


	void Update () {
		if(Input.GetButtonDown ("Jump")) //Cuando pulsa espacio salta
			saltar ();//mas abajo esta la funcion explicada

		if (Input.GetKey ("d")) { //cuando pulsa d se mueve a la derecha
						mover (lateralForce);//mover explicado abajo
			transform.localScale = new Vector3 (1,1,1);

				}
		if (Input.GetKey ("a")) {//cuando pulsa a se mueve a la izquierda
						mover (lateralForce * -1);
			transform.localScale = new Vector3 (-1,1,1);
				}//multipica por -1 para ir a la izquierda	
	}
	/*
	 *Funcion saltar
	 * Esta funcion aplica una fuerza hacia arriba definida por 
	 * la variable jumpForce
	 * TODO: Falta animacion de salto y sonido.
	 */
	void saltar() {
		if(!herido)
		//aplicamos la fuerza con rigidbody2D.AddForce 
		rigidbody2D.AddForce (new Vector2 (0, jumpForce));
		animation.SetBool ("fly", true);//activa la variable fly
		AudioSource.PlayClipAtPoint (sonidoVolar, transform.position);
		// new Vector2 (0, jumpForce) es un vector con la X a cero y la Y a jumpForce
		}
	//Esta es la funcion que detecta las colisiones
	void OnCollisionEnter2D(Collision2D coll){
				Debug.Log ("Choque");
		AudioSource.PlayClipAtPoint (sonidoChoque, transform.position);
		animation.SetBool ("fly", false);//con esto hacemos que el pajaro deje de volar al chocar
		if (coll.gameObject.tag == "enemy")
			//con esto detectamos si ha chocado contra un enemigo
						damage ();
		}
	//Con esta funcien detectamos si se ha atravesado un objeto
	void OnTriggerEnter2D(Collider2D other){
				if (other.gameObject.tag == "cura")//Detecta si el objeto que has atravesado cura.
						cura ();
		}
	//Funcion herir
	void damage() {
		animation.SetBool ("damage", true);
		AudioSource.PlayClipAtPoint (sonidohHerido, transform.position);
		herido = true;
		}//activa la variable damage

	void cura() {
		 
		animation.SetBool ("damage", false);
		AudioSource.PlayClipAtPoint (sonidoCurado, transform.position);
		herido = false;
	}

	/*
	 *Funcion mover
	 * Parametros: fuerza-> Fuerza que le vamos a aplicar para mover
	 * Aplicamos la fuerza horizontal teniendo en cuenta no sobrepasar
	 * la velocidad maxima
	 * 
	 */
	void mover(int fuerza){
		//creamos una variable para guardar la velocidad actual
		float velocity = rigidbody2D.velocity.x;//rigidbody2D.velocity.x tiene la informacion de la velocidad del vector en x
		//Mathf.Abs nos devuelve el valor absoluto de una variable.
		if ((fuerza > 0 & velocity < 0) || (fuerza < 0 & velocity > 0)) {
			rigidbody2D.velocity=new Vector2( 0,rigidbody2D.velocity.y);
		}

		if(Mathf.Abs(velocity) < maxSpeed)//comparamos la el valor absoluto de la velocidad actual del pollo con la velocidad maxima.
			////si la velocidad es menor que la maxima se aplica la fuerza.
			/// Tambien se puede aplicar escribiendo rigidbody2D.AddForce (new Vector2 (fuerza,0))
			rigidbody2D.AddForce (Vector2.right * fuerza);
		}
}
