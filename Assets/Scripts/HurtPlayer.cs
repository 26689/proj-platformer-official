using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{

    public int damagToGive = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            Vector3 hitDerection = other.transform.position - transform.position;
            hitDerection = hitDerection.normalized;

            FindObjectOfType<HealthManager>().HurtPlayer(damagToGive, hitDerection);
        }
    }
}
