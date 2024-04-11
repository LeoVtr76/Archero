using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public bool Col;
    public float PPPX;
    public float PPPZ;
    public Transform Player;
    public static Transform Target;
    // Start is called before the first frame update
    void Start()
    {
        PPPX = 1;
        PPPZ = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(PPPX, transform.localScale.y, PPPZ);
        transform.position = Player.position;
        if (Col == false)
        {
            PPPX += 0.1f;
            PPPZ += 0.1f;
        }
    }
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Bad")
        {
            Col = true;
            Target = other.gameObject.transform;
            StartCoroutine(Attack());
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bad")
        {
            Col = false;
            PPPX = 1;
            PPPZ = 1;
            StopCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        if (Target.GetComponent<ScriptEnnemi>().HP == 0)
        {
            Target.GetComponent<ScriptEnnemi>().HP -= 1;
            yield return new WaitForSeconds(1);
        }
    }
}
