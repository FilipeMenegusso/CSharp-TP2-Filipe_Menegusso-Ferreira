using System;

namespace TP02.ImobiliariaApp
{
    public class Imovel
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; private set; }
        public string Endereco { get; set; }

        public Imovel()
        {
            Id = Guid.NewGuid();
            DataCadastro = DateTime.Now;
        }
    }
}
