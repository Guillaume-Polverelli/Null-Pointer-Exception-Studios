using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ParcheminErrorText : MonoBehaviour
{

    private TMP_Text textMeshPro;
    public GameObject player;
    [SerializeField] private GameObject parchemin;
    [SerializeField] private float velocityText;

    private bool trigger = false;

    public void setPlayer(GameObject Player)
    {
        player = Player;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !trigger)
        {
            trigger = true;
            OnClickedAccepterQuete();
        }
    }

    public void Start()
    {
        textMeshPro = GetComponent<TMP_Text>();

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
        Destroy(parchemin);
        player.GetComponent<PlayerMovement>().setStopped(false);
        GameManager.Instance.UnlockRencontre2();
    }


}
