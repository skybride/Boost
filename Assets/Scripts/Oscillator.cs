using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent] //attribute that tells script to only allow one oscillator script on and object
public class Oscillator : MonoBehaviour {

    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f; //period is time it takes to complete 1 cycle

    // todo remeove from inspector later
    [Range(0, 1)] [SerializeField] float movementFactor;
    //0 for not moved, 1 for fully moved.

    Vector3 startingPos;
    
    // Use this for initialization
	void Start () {
        startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if(period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2; // PI is half a circle, Tau is a full circle therefore 2PI = Tau
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSinWave / 2f + 0.5f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
	}
}
