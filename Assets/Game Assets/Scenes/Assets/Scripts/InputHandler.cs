using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class InputHandler : MonoBehaviour
{
    public Vector2 InputVector { get; private set; }
    public Animator animator;
    public AudioClip foot, rolling, reloadSound;
    public Vector3 MousePosition { get; private set; }

    public static float horizontalMotion;
    public static float verticalMotion;
    public float force;
    public float throwForce;
    public GameObject granade;
    public Transform pos;
    public Image slider;
    public static int granadeCount = 3;
    public Text granadeCountText;
    public bool canRoll;
    public static bool gameOver = false;

    [SerializeField] private TopDownCharacterMover player;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameOver)
        {
            horizontalMotion = CrossPlatformInputManager.GetAxis("Horizontal");
            verticalMotion = CrossPlatformInputManager.GetAxis("Vertical");
            InputVector = new Vector2(horizontalMotion, verticalMotion);
            if (horizontalMotion != 0 || verticalMotion != 0)
            {
                animator.SetBool("moving", true);
                /*   if (horizontalMotion > 0 && verticalMotion == 0)
                   {
                       animator.SetBool("strafe right", true);
                       animator.SetBool("strafe left", false);
                   }
                   if (horizontalMotion < 0 && verticalMotion == 0)
                   {
                       animator.SetBool("strafe left", true);
                       animator.SetBool("strafe right", false);
                   }
                   if(verticalMotion != 0)
                       animator.SetBool("forward", true);*/
            }

            else
            {
                animator.SetBool("moving", false);
                animator.SetBool("strafe left", false);
                animator.SetBool("strafe right", false);
                animator.SetBool("forward", false);
            }

            MousePosition = Input.mousePosition;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                roll();
            }
            if (Input.GetKeyDown("y"))
            {
                testThrow();
            }
            if (Input.GetKeyDown("r"))
            {
                reload();
            }

            if (slider.fillAmount >= 1)
                canRoll = true;
            else
                canRoll = false;
            slider.fillAmount += 0.3f * Time.deltaTime;
            granadeCountText.text = "x" + granadeCount.ToString("0");
        }
    }

    public void roll()
    {
        if (!gameOver)
        {
            if (canRoll == true)
            {
                player.target = null;
                slider.fillAmount = 0;
                if (horizontalMotion != 0 || verticalMotion != 0)
                {
                    GetComponent<Rigidbody>().AddForce(new Vector3(InputHandler.horizontalMotion * force, 0, InputHandler.verticalMotion * force), ForceMode.Impulse);
                    StartCoroutine(animate("roll", 0.5f));
                    GetComponent<AudioSource>().clip = rolling;
                    GetComponent<AudioSource>().Play();
                }
            }
        }
        
    }
    IEnumerator animate(string name, float time)
    {
        Cannon.canFire = false;
        animator.SetBool(name, true);
        yield return new WaitForSeconds(time);
        animator.SetBool(name, false);
        Cannon.canFire = true;
    }

    public void testThrow()
    {
        if (!gameOver)
        {
            if (granadeCount > 0)
            {
                Instantiate(granade, pos.position, pos.rotation);
                StartCoroutine(animate("runThrow", 0.3f));
                granadeCount--;
            }
        }
    }
    public void reload()
    {
        StartCoroutine(animate("reload", 2));
        GetComponent<AudioSource>().clip = reloadSound;
        GetComponent<AudioSource>().Play();
    }

    public void footSound()
    {
        GetComponent<AudioSource>().clip = foot;
        GetComponent<AudioSource>().Play();
    }
}
