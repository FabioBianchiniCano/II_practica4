# II_practica3 - Cámara y Micrófono
## Fabio Bianchini Cano
------
## Introducción

La práctica que hemos realizado implementa las funciones de cámara y micrófono, más tratamiento de audio, en una escena de Unity.

-------
## Cámara
Para la implementación de la cámara, en nuestro script _Camara.cs_, hemos creado en la función Start, la creación del controlador de la cámara y el inicio de su ejecución. 

Este script está asociado al cubo que tiene el personaje en la cabeza, el cual, mediante un cambio de texturas, podemos ajustarle el valor del vídeo recogido por la cámara, dando la sensación que somos nosotros los que estamos en la cabeza del jugador.

```
private WebCamTexture webcam;

void Start() {
  if (webcam == null) 
    webcam = new WebCamTexture();

  GetComponent<Renderer>().material.mainTexture = webcam;

  if (!webcam.isPlaying)
    webcam.Play();
}
```
---

## Micrófono
Y, a su vez, para el micrófono, en el script _MyMicrophone.cs_ hemos instanciado la creación del objeto tipo _AudioSource_, el cual reproduce la entrada de audio del micrófono por defecto durante 50 segundos.

Este script está asociado a un objeto de tipo audio dentro de la escena, el cual está ligado al jugador, por lo tanto lo sigue físicamente por toda la escena, haciendo que el sonido siempre se escuche con la misma intensidad.

```
void Start() {
  AudioSource audioSource = GetComponent<AudioSource>();
  audioSource.clip = Microphone.Start("", true, 50, 44100);
  audioSource.Play();
}
```

## Adicional
Y como adición a la práctica, hemos decidido jugar un poco con la librería _AudioSource_ y, mediante un sencillo juego de bolos representado por seis cilindros y una esfera, hacer que el jugador pulsando la tecla **Z** empuje la esfera con fuerza mientras trata de derribar los bolos, todo esto acompañado de un sonido incorporado en los archivos de la escena, haciendo como si fuese el propio jugador que gritase y moviese la esfera con dicha fuerza.
```
# MyMicrophone
public AudioSource fusRoDah;
void Update() {
  if (Input.GetKey(KeyCode.Z)) {
    fusRoDah.Play();
  }
}
---------------------
---------------------

# Empujar.cs
private GameObject player;
public float distance = 20f;
public float force = 100f;
private Rigidbody m_Rigidbody;

void Start() {
  player = GameObject.FindGameObjectWithTag("MyCharacter");
  m_Rigidbody = GetComponent<Rigidbody>();
}

// Update is called once per frame
void Update() {
  if (Vector3.Distance(transform.position, player.transform.position) < distance && Input.GetKey(KeyCode.Z)) {
    Vector3 moveDir = transform.position - player.transform.position;
    m_Rigidbody.AddForce(moveDir * force);
  }        
}
```

## Resultado final

  <img src="gifs/1.gif">