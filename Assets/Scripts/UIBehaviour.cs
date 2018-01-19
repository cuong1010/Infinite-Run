using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class UIBehaviour : MonoBehaviour {
    public Image health,mana;
    public Text txtpercenthealth,txtPoint;
    public float maxhealth=100,maxmana;
    public float currenthealth,currentmana=0;
    int point = 0;

	// Use this for initialization
	void Start () {
        
        currenthealth = maxhealth;

	}
	
    void UpdateHealthBar()
    {
        health.rectTransform.localScale = new Vector3(currenthealth / maxhealth, 1);
        int percent = Convert.ToInt32((currenthealth / maxhealth)*100);
        txtpercenthealth.text=percent.ToString()+"%";
    }

    public void TakeDamge(float amount)
    {
        currenthealth -= amount;
        if (currenthealth <= 0)
        {
            currenthealth = 0;
            Debug.Log("Death");
        }
        UpdateHealthBar();
    }
    public void Heal(float amount)
    {
        currenthealth = Mathf.Clamp(currenthealth + amount, 0, maxhealth);
        UpdateHealthBar();
    }
    public void IncreaseMana(float amount)
    {
        currentmana += amount;
        if (currentmana > maxmana) currentmana = maxmana;
        mana.rectTransform.localScale = new Vector3(currentmana / maxmana,1);
    }
    public void UseSkill()
    {
        currentmana=0;
        mana.transform.localScale = new Vector3(0, 1);
    }
    public void UpdatePoint(int amount)
    {
        point += amount;
        txtPoint.text = point + " pts";
    }
}
