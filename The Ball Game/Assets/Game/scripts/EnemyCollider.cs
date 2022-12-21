using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    public bool isInside;
    // Start is called before the first frame update
    void Start()
    {
        isInside = false;
    }

    // Update is called once per frame
    void Update()
    {
        visibleSphere();
    }

    private void visibleSphere()
    {
        if(isInside)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 0.0720f, 0.314f, 0.314f);

        }
        else if(!isInside)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 1.000f, 0.283f, 0.314f);

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           isInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInside = false;
        }
    }


}
