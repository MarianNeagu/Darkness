using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour 
{

	public Transform playerT;
	public float moveSpeed, jumpForce;
	private bool butonSus, butonDreapta, butonStanga;
	public bool onGround;
	public Rigidbody2D rb;
	public LayerMask groundLayers;
	public AudioSource jumpSound;
	public bool firstJumped;
	public bool soundPlayed;
	public bool justOnce;
	public GameObject groundParticle;
	[SerializeField]
	private bool particleSpawned;
	private Vector3 relativeGroundPosition;
	public ParticleSystem playerParticleSys;

	void Start()
	{
		soundPlayed = false;
		firstJumped = false;
		justOnce = true;
	}

	void Update()
	{
		//////////      GROUND CHECK     ////////////
		onGround = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.7f, transform.position.y - 0.8f), 
			new Vector2(transform.position.x + 0.7f, transform.position.y - 0.7f),groundLayers);


		//TESTARE PENTRU PC:

		if(Input.GetKey(KeyCode.W))
			if(onGround)
				butonSus = true;
		if(Input.GetKeyDown(KeyCode.D))
			butonDreapta = true;
		if(Input.GetKeyDown(KeyCode.A))
			butonStanga = true;
		if(Input.GetKeyUp(KeyCode.D))
			butonDreapta = false;
		if(Input.GetKeyUp(KeyCode.A))
			butonStanga = false;

		//////// GROUND PARTICLE SYSTEM //////////
		relativeGroundPosition = new Vector3(transform.position.x,transform.position.y-0.9f,transform.position.z);
		if(onGround)
		{
			if(particleSpawned)
			{
				Instantiate(groundParticle, relativeGroundPosition, Quaternion.Euler(90f,-90f,0f));
				particleSpawned = false;
			}
		}
		else particleSpawned = true;

		if(butonDreapta || butonStanga)
		{
			playerParticleSys.enableEmission = true;
		}
		else playerParticleSys.enableEmission = false;
	}

	void FixedUpdate()
	{

		if(butonSus)  
		{
			jumpSound.Play();
			rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
			butonSus = false;
			if(justOnce)
			{
				firstJumped = true;
				justOnce = false;
			}
		}
		if(butonStanga)
		{
			transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);//mS = 6 editor angularDrag=0.05
			
		}
			 

		if(butonDreapta)
		{
			transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
			
		}

	}
/////////////    SUS     ///////////////
	public void SusPointerDown()
	{
		if(onGround)
			butonSus = true;
	}
	public void SusPointerUp()
	{
		butonSus = false;
	}

/////////////  STANGA    ////////////////
	public void StangaPointerDown()
	{
		butonStanga = true;
		playerParticleSys.enableEmission = true;
	}
	public void StangaPointerUp()
	{
		butonStanga = false;
		playerParticleSys.enableEmission = false;	
	}
/////////////   DREAPTA     ///////////////
	public void DreaptaPointerDown()
	{
		butonDreapta = true;
		playerParticleSys.enableEmission = true;
	}
	public void DreaptaPointerUp()
	{
		butonDreapta = false;
		playerParticleSys.enableEmission = false;	
	}



}
