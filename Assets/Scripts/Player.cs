using UnityEngine;

public class Player : MonoBehaviour
{

    private void Update()
    {
        Managers.Instance.ShowUI();
    }

    public void PlaySound()
    {
        Debug.Log("PlaySound");
    }


}
