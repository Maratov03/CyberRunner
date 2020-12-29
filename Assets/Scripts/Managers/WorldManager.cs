using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    //public GameObject RoadPrafeb;
    private List<GameObject> roads=new List<GameObject>();
    public float maxspeed;
    private float speed;
    public float maxRoadCount;
    public float endZ;
    public float offset;
    public TownFabrica townFabrica;

    private void Awake()
    {
        townFabrica = GetComponent<TownFabrica>();
        offset = offset * townFabrica.scaleZFactor;
    }
    void Start()
    {
        ResetLevel();
        StartLevel();
    }

    void StartLevel()
    {
        speed = maxspeed;
    }
    void Update()
    {
        if (speed == 0) return;
        foreach(GameObject road in roads)
        {
            road.transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
        }
        if (roads[0].transform.position.z < -endZ)
        {
            Destroy(roads[0]);
            roads.RemoveAt(0);
            CreateNextRoad();
        }
    }
    private void CreateNextRoad()
    {
        Vector3 pos = Vector3.zero;
        if (roads.Count > 0) { pos =  roads[roads.Count - 1].transform.position + new Vector3(0, 0, offset); pos.x = transform.position.x; pos.y = transform.position.y; }
        GameObject go = townFabrica.CreateCity(pos);//  Instantiate(RoadPrafeb, pos, Quaternion.identity);
        go.transform.SetParent(transform);
        roads.Add(go);
    }

    public void ResetLevel()
    {
        speed = 0;
        while (roads.Count > 0)
        {
            Destroy(roads[0]);
            roads.RemoveAt(0);
        }
        for(int i=0; i<maxRoadCount; i++)
        {
            CreateNextRoad();
        }
    }
}
