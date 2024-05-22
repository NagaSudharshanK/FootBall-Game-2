using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public Transform target;
    public float force;
    public Slider forceUI;
  
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            force+=1;
            slider();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            shoot();
            StartCoroutine(Wait());
        }
        
    }
    void shoot()
    {
        Vector3 shoot = (target.position - this.transform.position).normalized;
        GetComponent<Rigidbody>().AddForce(shoot * force + new Vector3(0, 3f, 0), ForceMode.Impulse);
    }

    public void slider()
    {
        forceUI.value = force;
    }

    public void ResetGauge()
    {
        force = 0;
        forceUI.value = 0;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        ResetGauge();
    }
}
