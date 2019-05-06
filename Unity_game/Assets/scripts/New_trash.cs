using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_trash : MonoBehaviour {
    public int pause_time;
    public int max_pause;
    public GameObject  []trash_prefab;
    public player_controller control;
    // Use this for initialization
    void Start () {
        control= GameObject.FindWithTag("Player").GetComponent<player_controller>();
    }
	
	// Update is called once per frame
	void Update () {
        pause_time -= 1;
        if (pause_time < 1) pause_time = max_pause;
        else if (pause_time == 1 && control.moretrash) create();
    }

    void create() {
        int type = Random.Range(0, trash_prefab.Length);
        int x = Random.Range(121, 291);
        int y = 5;
        int z = Random.Range(140, 490);
        Vector3 pos = new Vector3(x, y, z);
        Instantiate(trash_prefab[type], pos, Quaternion.identity);
        control.total_Existing += 1;
        control.pollution += control.trashPollution;
    }
}
