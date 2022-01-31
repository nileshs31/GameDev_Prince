using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Vector3 Pos;
    public GameObject[] obstacles;
    public int ss;
    public float waitTime;
    void Start()
    {
        Pos = transform.position;
        StartCoroutine(objSpawner());
    }
    void FixedUpdate()
    {
        if (waitTime > 0.5f)
            waitTime -= 0.000007f;//---------------
        ss = Random.Range(0, 2);

    }

    public IEnumerator objSpawner()
    {
        
        if (ss == 0)
        {
            yield return new WaitForSeconds(waitTime);
            while (true)
            {

                yield return new WaitForSeconds(waitTime + 3.7f);
                Instantiate(obstacles[ss], new Vector3(Pos.x, Pos.y, Pos.z), Quaternion.identity);

            }
        }
        if(ss==1)
        {
            yield return new WaitForSeconds(waitTime);
            while (true)
            {

                yield return new WaitForSeconds(waitTime + 3.7f);
                Instantiate(obstacles[ss], new Vector3(Pos.x, Pos.y, Pos.z), Quaternion.identity);

            }
        }
    }
    
}
