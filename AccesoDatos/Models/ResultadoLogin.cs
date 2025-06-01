using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Models
{
    public class ResultadoLogin
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Usuario Data { get; set; }
        public string Token { get; set; }

    }
}
