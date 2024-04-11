using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class ScriptEnnemi : MonoBehaviour
{
    public Slider BarreHP;
    public GameObject target;
    public int HP;

    // Start is called before the first frame update
    void Start()
    {
        BarreHP.value = 1;
        HP = 10;
    }

    // Update is called once per frame
    void Update()
    {
      if (HP == 0)
        {
            gameObject.SetActive(false);
        }
        GetComponent<NavMeshAgent>().destination = target.transform.position;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            BarreHP.value -= 0.05f;
        }
    }
}
