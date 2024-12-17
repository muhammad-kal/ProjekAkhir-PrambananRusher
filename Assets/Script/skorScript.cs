using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class skorScript : MonoBehaviour
{
    private TextMeshProUGUI candiCounterText;
    public int banyakCandi=0;

    private void Awake()
    {
        building.signalCandiTerbangun += RunCo;
        candiCounterText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        candiCounterText.text = "X" + 0;
    }

    private void Update()
    {
        candiCounterText.text = "X" + banyakCandi.ToString();
        
    }

    private IEnumerator Pulse()
    {
        for (float i = 1f; i <= 1.2f; i+= 0.05f)
        {
            candiCounterText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }

        candiCounterText.rectTransform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        banyakCandi += 1;

        for (float i = 1.2f; i >= 1f; i -= 0.5f)
        {
            candiCounterText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        
        candiCounterText.rectTransform.localScale = new Vector3(1f,1f, 1f);
    }

    private void RunCo()
    {
        StartCoroutine(Pulse());
    }

    private void OnDestroy()
    {
        building.signalCandiTerbangun -= RunCo;
    }
}
