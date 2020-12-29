using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownFabrica : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> towers;
    [SerializeField]
    private List<Material> towerMaterials;   
    [SerializeField]
    private GameObject currenttower;
    [SerializeField]
    private Material currenttowermaterial;
    public float scaleXFactor;
    public float scaleYFactor;
    public float scaleZFactor;
    public GameObject CreateCity(Vector3 pos)
    {
        currenttower = Instantiate(towers[Random.RandomRange(0, towers.Count)],pos, Quaternion.identity);       
        currenttower.GetComponent<MeshRenderer>().material= towerMaterials[Random.RandomRange(0, towerMaterials.Count)];        
        currenttower.transform.localScale = new Vector3(scaleXFactor,Random.RandomRange(5, scaleYFactor+5), scaleZFactor);
        return currenttower;
    }
}
