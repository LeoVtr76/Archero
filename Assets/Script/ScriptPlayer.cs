using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScriptPlayer : MonoBehaviour
{
    public static float Z;
    Animator anim;
    public static float PosZ;
    public Transform target;
    public Transform cursor;
    public float hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = 1;
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        target = Radar.Target;
       

            Vector3 relativePos = cursor.position - transform.position;
            relativePos = new Vector3(relativePos.x, 0, relativePos.z);
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = rotation;
    }
    void FixedUpdate()
    {
        PosZ = gameObject.transform.position.z;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            transform.Translate(0, 0, 10 * Time.deltaTime);
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
    }
}
