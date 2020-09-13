using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour
{
    // Start is called before the first frame update
    protected PlayerMovement playerMovement;
    protected Button jumpButton;
    void Start()
    {
        playerMovement =  GameObject.FindWithTag(TagHelper.Player).GetComponent<PlayerMovement>();
        jumpButton = transform.GetComponent<Button>();
        
    }

    // Update is called once per frame
    void Update()
    {
        jumpButton.onClick.AddListener(playerMovement.Jumping);
    }
}
