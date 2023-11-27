using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ronin : MonoBehaviour
{
    public Animator r_Anim;

    public Transform player;
    bool isFlipped = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Stand());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Stand()
    {
        yield return new WaitForSeconds(0.8f);

        r_Anim.enabled = true;

        r_Anim.SetBool("Idle", true);
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        } else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
