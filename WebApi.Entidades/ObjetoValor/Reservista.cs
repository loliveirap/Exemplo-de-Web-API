using System;

namespace WebApi.Entidades.ObjetoValor
{
    public class Reservista
    {
        public virtual string Numero { get; set; }
        public virtual string RM { get; set; }

        public virtual string Serie { get; set; }

        public virtual string CSM { get; set; }

        public virtual string CAT { get; set; }

        public virtual DateTime? Expedicao { get; set; }
    }
}
