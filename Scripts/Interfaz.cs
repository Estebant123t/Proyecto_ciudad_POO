using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interfaz : MonoBehaviour
{
    [SerializeField] private GameObject m_RegistroUI = null;
    [SerializeField] private GameObject m_LoginUI = null;
    [SerializeField] private Text m_text = null;
    [SerializeField] private InputField m_usernameInput = null;
    [SerializeField] private InputField m_passwordInput = null;
    [SerializeField] private InputField m_ConpasswordInput = null;
    private NetworkManager m_NetworkManager = null;
    private void Awake()
    {
        m_NetworkManager = GameObject.FindObjectOfType<NetworkManager>();
    }
    public void ProcessLogin()
    {
        if (m_usernameInput.text == "" || m_passwordInput.text == "" || m_ConpasswordInput.text == "")
        {
            m_text.text = "Asegurese de completar todos los espacios.";
            return;

        }
        if (m_passwordInput.text == m_ConpasswordInput.text)
        {
            m_text.text = "Procesando...";
            m_NetworkManager.CreateUser(m_usernameInput.text, m_passwordInput.text, delegate (Response response)
            {
                m_text.text = response.message;
            });
        }
        else
        {
            m_text.text = "Contraseńas diferentes.";
        }
    }
    public void ShowLogin()
    {
        m_RegistroUI.SetActive(false);
        m_LoginUI.SetActive(true);
    }
    public void ShowRegistrar()
    {
        m_RegistroUI.SetActive(true);
        m_LoginUI.SetActive(false);

    }

}
