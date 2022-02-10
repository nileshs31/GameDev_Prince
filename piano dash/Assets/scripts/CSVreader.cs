using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVreader : MonoBehaviour
{
    // Start is called before the first frame update
    public TextAsset CSVfile;
    string[] words;
    void Start()
    {
        string[] lines = CSVfile.text.Split(new char[] { '\n' });
        Debug.Log(lines.Length);
        for(int i = 1; i < lines.Length - 1; i++)
        {
            //words = CSVfile.text.Split(new char[] { ',' });
            words = lines[1].Split(new char[] { ',' });
        }
        for(int j = 0; j < words.Length; j++)
        {
            Debug.Log(words[j]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
