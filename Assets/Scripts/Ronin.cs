using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ronin : MonoBehaviour
{
    public Animator r_Anim;
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
        yield return new WaitForSeconds(2.0f);

        r_Anim.SetInteger("fdnsaasofao", 1);

        yield return new WaitForSeconds(0.5f);

        r_Anim.SetInteger("fdnsaasofao", 2);
    }
}
