using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Parchemin : MonoBehaviour
{
    [SerializeField] private TMP_Text textMeshPro;
    [SerializeField] private float velocityText;
    // Start is called before the first frame update

    private NPCInteractable npc;

    void Start()
    {
        npc = GetComponent<NPCInteractable>();
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ParcheminCollected()
    {
        npc.SetNbDialog(npc.GetNbDialog()+1);
    }

    public void OnClickedAccepterQuete()
    {
        StartCoroutine(Writer("ACCESS DENIED ACCESS DENIED ACCESS DENIED ACCESS DENIED ACCESS DENIED ACCESS DENIED ACCESS DENIED ACCESS DENIED ACCESS DENIED ACCESS DENIED " +
            "ACCESS DENIED ACCESS DENIED ACCESS DENIED ACCESS DENIED ACCESS DENIED ACCESS DENIED ACCESS DENIED ACCESS DENIED ACCESS DENIED ACCESS DENIED"));
    }


    public IEnumerator Writer(string text)
    {
        float pourcentage = 0f;
        float textVelocity = (1f / text.Length);

        while (pourcentage < 1f)
        {

            pourcentage = (pourcentage + textVelocity) * 5;
            int nbCharacter = (int)(text.Length * pourcentage);

            string h;
            if (nbCharacter >= text.Length) h = text;
            else h = text.Substring(0, nbCharacter);
            textMeshPro.SetText(h);
            yield return new WaitForSeconds(velocityText);
        }

        yield return new WaitForSeconds(Random.Range(1.5f, 3f));
        Cursor.visible = false;
        Destroy(gameObject);
    }
}
