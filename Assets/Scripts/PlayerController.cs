using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody playerRigid;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce;
    public float gravityModifier;
    private bool isGround;
    public bool isGameOver;
    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGround == true && isGameOver != true)
        {
            playerRigid.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            isGround = false;
            playerAudio.PlayOneShot(jumpSound,0.6f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            dirtParticle.Play();
        }
      else if(collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound,0.6f);
        }
    }
}
