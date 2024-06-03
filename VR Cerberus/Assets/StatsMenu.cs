using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsMenu : MonoBehaviour
{
    [SerializeField]
    private CerberusStats cerberusStats;

    public Slider hygieneSlider;
    public Slider satiationSlider;
    public Slider funSlider;
    public Slider affectionSlider;

    // Start is called before the first frame update
    void Start()
    {
        cerberusStats = GameObject.Find("Cerberus").GetComponent<CerberusStats>();
        hygieneSlider.value = cerberusStats.hygiene;
        satiationSlider.value = cerberusStats.satiation;
        funSlider.value = cerberusStats.fun;
        affectionSlider.value = cerberusStats.affection;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.active && cerberusStats != null)
        {
            hygieneSlider.value = cerberusStats.hygiene;
            satiationSlider.value = cerberusStats.satiation;
            funSlider.value = cerberusStats.fun;
            affectionSlider.value = cerberusStats.affection;
        }
        else 
        {
            Debug.Log("Cerberus Stats Not Found");
        }
    }
}
