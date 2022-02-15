using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New VegetablesData", menuName = "Vegetavles Data", order = 51)]
public class Vegetables : ScriptableObject
{
    [SerializeField] float timeCucumber;
    [SerializeField] float timeTomato;
    [SerializeField] float timeWheat;
    [SerializeField] GameObject CucumberGameObject;
    [SerializeField] GameObject TomatoGameObject;
    [SerializeField] GameObject WheatGameObject;

    public float GetTimeCucumber() =>
        timeCucumber;
    public float GetTimeTomato() =>
        timeTomato;
    public float GetTimeWheat() =>
        timeWheat;
    public GameObject GetCucumber() =>
        CucumberGameObject;
    public GameObject GetTomate() =>
        TomatoGameObject;
    public GameObject GetWheat() =>
        WheatGameObject;

    public float GetTimeByName(VegetablesState state) 
    {
        switch (state) 
        {
            case VegetablesState.Ñucumber: return timeCucumber;
            case VegetablesState.Tomato: return timeTomato;
            case VegetablesState.Wheat: return timeWheat;
            default: return -1;
        }
    }
    public GameObject GetGameObjectByName(VegetablesState state) 
    {
        switch (state)
        {
            case VegetablesState.Ñucumber: return CucumberGameObject;
            case VegetablesState.Tomato: return TomatoGameObject;
            case VegetablesState.Wheat: return WheatGameObject;
            default: return null;
        }
    }
}
