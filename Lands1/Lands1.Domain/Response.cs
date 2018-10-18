//clase para guardar las respuestas de los Servicios que consumo, se mueve a Domain para usarlo en todos los proyectos
namespace Lands1.Domain
{
    public class Response
    {
        public bool IsSuccess
        {
            get;
            set;
        }
        public string Message
        {
            get;
            set;
        }
        public object Result
        {
            get;
            set;
        }
    }
}
