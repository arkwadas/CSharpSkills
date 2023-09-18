using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarierActivate : MonoBehaviour
{
    public Barier barier;
    // Start is called before the first frame update
    void Start()
    {
        //barier = GetComponent<Barier>();
    }

    // Update is called once per frame
    void Update()
    {
        barier.BarrierSkill();
    }
}
