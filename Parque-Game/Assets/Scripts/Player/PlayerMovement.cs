using UnityEngine;

public class PlayerMovemment : MonoBehaviour
{
   public float speed = 5f;
   public float rotationSpeed = 10f;
   
   private CharacterController controller;

   void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    
    {
        if(ConfirmacaoUI.Instance?.uiPanel != null && ConfirmacaoUI.Instance.uiPanel.activeSelf == true)

        {
            return; 
        }
        else
        {
            MovePlayer();
        }
    }
    public void MovePlayer()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direcao = new Vector3(horizontal, 0f, vertical).normalized;
        
        controller.Move(direcao * speed * Time.deltaTime);
        
        if (direcao != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direcao), Time.deltaTime * rotationSpeed);          
        }
    }
}
