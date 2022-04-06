using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bluepiece : Playerpiece
{
    // Start is called before the first frame update
    public int moves = 0;
    public Animator rollingdiceanim;
    public GameObject rollingdice;
    public GameObject[] dices;
    int temp = 0;
    void Start()
    {
        rollingdice.SetActive(true);
    }
    public void randm()
    {
        for (int j = 0; j < 6; j++)
        {
            dices[j].SetActive(false);
        }
        moves = Random.Range(1, 7);
        rollingdice.SetActive(true);
        rollingdiceanim.enabled = true;
        Invoke("stopanim", 2f);
    }
    public void stopanim()
    {
        rollingdiceanim.enabled = false;
        rollingdice.SetActive(false);
        Debug.Log(moves);
        dices[moves-1].SetActive(true);
        moveplayer();
    }
    // Update is called once per frame
    public void moveplayer()
    {
        for (int i = 0; i < temp + moves; i++)
        {
            transform.position = pathpointparent.commonpathpoint[i].transform.position;
        }
        temp += moves;
    }
}
