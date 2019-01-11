using System;

namespace Encriptaciones
{
    public class EncriptarCorreo
    {
        #region Propiedades
        private string _Asunto;

        public string Asunto
        {
            get { return _Asunto; }
            set { _Asunto = value; }
        }

        private string _Contenido;

        public string Contenido
        {
            get { return _Contenido; }
            set { _Contenido = value; }
        }

        private string _Destinatario;

        public string Destinatario
        {
            get { return _Destinatario; }
            set { _Destinatario = value; }
        }

        private string _Enviador;

        public string Enviador
        {
            get { return _Enviador; }
            set { _Enviador = value; }
        }

        private string _Contraseña;

        public string Contraseña
        {
            get { return _Contraseña; }
            set { _Contraseña = value; }
        }
        #endregion

        #region Constructores
        public EncriptarCorreo(string Subject, string Body, string To)
        {
            this.Asunto = Subject;
            this.Contenido = Body;
            this.Destinatario = To;
        }
        #endregion
    }
}
