using System;
using System.Collections.Generic;
using System.Text;

namespace MetodosEstaticosInstancia
{
    /* Cada instância de Bateria contém um número de série. 
     * O construtor é como um método de instância e inicializa a nova instância com o próximo número de série 
     * disponível.
     * 
     * Mas como incrementar um número se não sabemos a sequencia inicial?
     * O campo proximoNumeroSerie e o método DefinirSequenciaInicial são membros estáticos, logo conseguimos 
     * definir a sequencia inicial antes da instancia ser criada
     * 
     * Como o construtor é um membro de instância, ele tem permissão para acessar tanto o campo de instância 
     * numeroSerie e o campo estático proximoNumeroSerie.
     */

    public class Bateria
    {
        private static int proximoNumeroSerie;
        public int NumeroSerie { get; set; }

        public Bateria()
        {
            proximoNumeroSerie++;
            NumeroSerie = proximoNumeroSerie;
        }

        public int ObterNumeroSerie()
        {
            return NumeroSerie;
        }

        public static int ObterProximoNumeroSerie()
        {
            return proximoNumeroSerie;
        }

        public static void DefinirSequenciaInicial(int numero)
        {
            proximoNumeroSerie = numero;
        }
    }
}
