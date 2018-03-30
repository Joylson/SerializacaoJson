using System.Runtime.Serialization;

namespace Seliazacao_Json.Modal
{
    [DataContract]
    public class Pessoa
    {
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public int Idade { get; set; }

        public Pessoa(string nome, int idade)
        {
            this.Nome = nome;
            this.Idade = idade;
        }
    }
}
