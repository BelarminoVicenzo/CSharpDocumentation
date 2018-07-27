using ExtensionMethods;
using System;

namespace MetodosExtensao
{
    public static class MinhasExtensoes
    {
        public static int ContarPalavras(this String str)
        {
            return str.Split(new char[] {' ', '.', '?' }, 
                StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static Nota minimoParaPassar = Nota.D;

        public static bool Passou(this Nota nota)
        {
            return nota >= minimoParaPassar;
        }
    }


}
