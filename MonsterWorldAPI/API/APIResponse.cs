using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonsterWorldAPI.API
{
    public class APIResponse<T>
    {
        //Propriedades genéricas para retornarem uma resposta nas solicitações da API
        public bool Succeed { get; set; }
        public string Message { get; set; }
        public T Results { get; set; }
    }
}
