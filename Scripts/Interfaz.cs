using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interfaz : MonoBehaviour
{
    [SerializeField] private GameObject m_RegistroUI = null;
    [SerializeField] private GameObject m_LoginUI = null;
    [SerializeField] private GameObject m_textoGO = null;
    [SerializeField] private GameObject m_nombreUsuarioInGO = null;
    [SerializeField] private GameObject m_contrasenaInGO = null;
    [SerializeField] private GameObject m_ConfcontrasenaInGO = null;
    private Text m_texto;
    private InputField m_nombreUsuarioIn;
    private InputField m_contrasenaIn;
    private InputField m_ConfcontrasenaIn;
    private BaseenWeb m_BaseenWeb;
    private void Awake()
    {
        m_BaseenWeb = GameObject.FindObjectOfType<BaseenWeb>();

    }
    public void ProcesoRegistro()
    {
        m_texto = m_textoGO.GetComponent<Text>();
        m_nombreUsuarioIn = m_nombreUsuarioInGO.GetComponent<InputField>();
        m_contrasenaIn = m_contrasenaInGO.GetComponent<InputField>();
        m_ConfcontrasenaIn = m_ConfcontrasenaInGO.GetComponent<InputField>();

        if (m_nombreUsuarioIn.text == "" || m_contrasenaIn.text == "" || m_ConfcontrasenaIn.text == "")
        {
            m_texto.text = "Asegurese de completar todos los espacios.";
            return;

        }
        if (m_contrasenaIn.text == m_ConfcontrasenaIn.text)
        {
            m_texto.text = "Procesando...";
            m_BaseenWeb.CrearUsuario(m_nombreUsuarioIn.text, m_contrasenaIn.text, delegate (Respuesta response) 
            {
                m_texto.text = response.mensaje;
            });
        }
        else
        {
            m_texto.text = "Contraseñas diferentes.";
        }
    }
    public void MostrarLogin()
    {
        m_RegistroUI.SetActive(false);
        m_LoginUI.SetActive(true);
    }
    public void MostrarRegistrar()
    {
        m_RegistroUI.SetActive(true);
        m_LoginUI.SetActive(false);

    }

}
