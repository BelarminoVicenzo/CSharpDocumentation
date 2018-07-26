using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

namespace ClienteWebApi
{
    //Mapeamento do objeto JSON para objeto C# com nome de classes diferentes
    [DataContract(Name = "repo")]
    public class Repositorio
    {
        //Mapeamento do objeto JSON para objeto C# com nome de propriedades diferentes
        [DataMember(Name = "name")]
        public string Nome { get; set; }

        [DataMember(Name = "description")]
        public string Descricao { get; set; }

        [DataMember(Name = "html_url")]
        public Uri GitHubHomeUrl { get; set; }

        [DataMember(Name = "homepage")]
        public Uri Homepage { get; set; }

        [DataMember(Name = "watchers")]
        public int Seguidores { get; set; }

        [DataMember(Name = "pushed_at")]
        private string DataFormatoJson { get; set; }

        //Instrui o serializador Json a não ler ou gravar essa propriedade
        [IgnoreDataMember]
        public DateTime UltimoPush {
            get
            {
                return DateTime.ParseExact(DataFormatoJson, "yyyy-MM-ddTHH:mm:ssZ", 
                    CultureInfo.InvariantCulture);
            }
        }
    }
}
