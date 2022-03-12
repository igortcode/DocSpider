using System;

namespace DS.Business.Entities
{
    public class Log : Entity
    {
        public string Mensagem { get; set; }
        public DateTime DataModificacao { get; set; }
    }
}
