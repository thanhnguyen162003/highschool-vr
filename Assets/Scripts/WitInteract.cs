using Meta.WitAi.Json;
using Meta.WitAi.Requests;
using Meta.WitAi;
using TMPro;
using UnityEngine;

public class WitInteract : MonoBehaviour
{
    [SerializeField] private Wit wit;

    public TextMeshProUGUI myText;

   
    public void PushAndHold()
    {
        wit.Activate();
        myText.text = "Bạn đang nói";

    }

    public void Release()
    {
        wit.Deactivate();
        myText.text = "Đang không nói";

    }
    
}
