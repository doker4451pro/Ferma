using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Garden : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private Vegetables vegetablesData;

    private GardenState currentState;
    private VegetablesState vegetablesState;
    private BaseVegetable vegetable;
    public void TryPlantVegetable(VegetablesState state) 
    {
        if (currentState == GardenState.None) 
        {
            vegetablesState = state;
            PlantVegetable();
        }
    }

    private void PlantVegetable() 
    {
        switch (vegetablesState) 
        {
            case VegetablesState.Ñucumber:
                StartCoroutine(Growing(vegetablesData.GetCucumber(), vegetablesData.GetTimeCucumber()));
                break;
            case VegetablesState.Tomato:
                StartCoroutine(Growing(vegetablesData.GetTomate(), vegetablesData.GetTimeTomato()));
                break;
            case VegetablesState.Wheat:
                StartCoroutine(Growing(vegetablesData.GetWheat(), vegetablesData.GetTimeWheat()));
                break;
        }
    }
    private IEnumerator Growing(GameObject gameObject,float time) 
    {
        vegetable= Instantiate(gameObject, transform).GetComponent<BaseVegetable>();
        currentState = GardenState.Growing;
        yield return new WaitForSeconds(time);
        currentState = GardenState.Matured;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (currentState == GardenState.Matured) 
        {
            vegetable.Move(vegetablesState);
            currentState = GardenState.None;
        }
    }

}
