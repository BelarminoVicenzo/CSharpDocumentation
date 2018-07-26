using System;

namespace BibliotecasUteis
{
    public static class UteisString
    {
        public static bool IniciaComMaiuscula(this string str)
        {
            if (String.IsNullOrWhiteSpace(str))
                return false;

            Char ch = str[0];
            return Char.IsUpper(ch);
        }
    }
}