//clase para guardar las respuestas de los Servicios que consumo
namespace Lands1.Models
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
