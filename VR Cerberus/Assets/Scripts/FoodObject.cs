using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodObject : MonoBehaviour
{
    public int totalBites;
    int bitesLeft;
    [SerializeField] private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        bitesLeft = totalBites;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public bool IsEaten() {  return bitesLeft <= 0; }

    public void TakeBite() 
    { 
        bitesLeft--; 
        audioSource.Play();
    }
}
