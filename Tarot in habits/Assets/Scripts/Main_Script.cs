using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Script : MonoBehaviour
{
    [Tooltip ("Карты игры")]
    public Transform[] Karts;
    public Animator[] AnimKarts;

    public Animator ScaleKarts;



    void Start()
    {
        for (int i = Karts.Length - 1; i >= 1; i--)
        {
            int j = Random.Range(0, Karts.Length);
            // обменять значения data[j] и data[i]
            //Debug.Log(j + "==>" + i);
            Animator temp = AnimKarts[j];
            Transform temp2 = Karts[j];

            AnimKarts[j] = AnimKarts[i];
            AnimKarts[i] = temp;

            Karts[j] = Karts[i];
            Karts[i] = temp2;
        }
         
        
        Vector3 Vectorr = new Vector3 (0, 0, 0);
        for(int i = 0; i < Karts.Length; i++)
        {
            Karts[i].transform.localPosition  =  Vectorr;
            Vectorr = new Vector3 (Vectorr.x, Vectorr.y, Vectorr.z - 0.03f);
        }
    }

    /*private void RandAnim(int _i, int _j)
    {
        if(_j == 0)
        {
            AnimKarts[_i].SetBool("Padenie", true);
        }

    }*/

    public void NewKarts()
    {
        StartCoroutine (Peremeshivanie());
    }

    IEnumerator Peremeshivanie()
    {
        ScaleKarts.SetBool("Exit", false);
        ScaleKarts.enabled = true;

        
        for (int i = 0; i < 30; i++)
        {
            int RR = Random.Range(0, Karts.Length);
            int j = Random.Range(1, 2);
            int o = Random.Range(1, 2);
            yield return new WaitForSeconds (0.1f);
            
            AnimKarts[RR].SetInteger("KakMeshat", j); 
            AnimKarts[RR].SetInteger("KydaNesti", o);

            if (o == 1)
            {
                Karts[i].transform.localPosition  += new Vector3 (0, 0, Random.Range(0.01f, 0.9f));
            }
            else
            {
                Karts[i].transform.localPosition  -= new Vector3 (0, 0, Random.Range(0.01f, 0.9f));
            }
            
        } 
        yield return new WaitForSeconds (4f);
        ScaleKarts.SetBool("Exit", true);
        yield return new WaitForSeconds (1f);
        ScaleKarts.enabled = false;
        for (int i = 0; i < AnimKarts.Length; i++)
        {
            AnimKarts[i].enabled = false;
            AnimKarts[i].SetInteger("KakMeshat", 0); 
            AnimKarts[i].SetInteger("KydaNesti", 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
