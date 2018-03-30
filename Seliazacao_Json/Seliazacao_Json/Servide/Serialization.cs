using Seliazacao_Json.Modal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Seliazacao_Json.Servide
{
    public class Serialization
    {
        public void Serializar(string nome, int idade)
        {

            var pessoa = new Pessoa(nome, idade);
            var pessoas = new List<Pessoa>();

            //Stream de ligação de arquivo 
            FileStream stream;
            //Formato de serialização
            var sr = new DataContractJsonSerializer(typeof(List<Pessoa>));

            if (!(File.Exists(@"Pessoas.json")))
            {
                //criar arquivo
                stream = new FileStream(@"Pessoas.json", FileMode.Create);
            }
            else
            {
                //abrir arquivo
                stream = new FileStream(@"Pessoas.json", FileMode.Open);
                pessoas = (List<Pessoa>)sr.ReadObject(stream);

            }

            //Adicionar Nova pessoa a lista
            pessoas.Add(pessoa);

            //modificando arquivo serializado
            stream.Position = 0;
            sr.WriteObject(stream, pessoas);
            stream.Close();
        }



        public IEnumerable<Pessoa> Deserializar()
        {
            //Stream de ligação de arquivo
            FileStream stream;
            if (File.Exists(@"Pessoas.json"))
            {
                //Abrir Arquivo
                stream = new FileStream(@"Pessoas.json", FileMode.Open);
                var sr = new DataContractJsonSerializer(typeof(List<Pessoa>));
                //Deserializar arquivo
                var pessoas = (List<Pessoa>)sr.ReadObject(stream);
                //Fechar arquivo                       
                stream.Close();
                //returnar arquivo
                return pessoas;
            }
            else
            {

                throw new FieldAccessException("Arquivo não existe");
            }
        }
    }
}
