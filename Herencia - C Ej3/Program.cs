using System;

namespace Herencia___C_Ej3
{
    class Password
    {
        public string contrasena { get; }
        public int longitud { get; set; }

        public Password()
        {
            longitud = 8;
            contrasena = generarPassword();
        }

        public Password(int nlongitud)
        {
            longitud = nlongitud;
            contrasena = generarPassword();
        }
        public string generarPassword()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[longitud];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            return (new string(stringChars));
        }
        public Boolean esFuerte()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Boolean encontrado = false;
            int mayus = 0;
            int minus = 0;
            int numeros = 0;

            for(int i = 0; i < contrasena.Length; i++)
            {
                for (int j = 0; j < chars.Length & !encontrado; j++)
                {
                    if (chars[j] == contrasena[i])
                    {
                        encontrado = true;
                        if (j < 26)
                        {
                            mayus++;
                        }
                        else
                        {
                            if (j > 51)
                            {
                                numeros++;
                            }
                            else
                            {
                                minus++;
                            }
                        }
                    }
                }
                encontrado = false;
            }

            if ((mayus > 2) & (minus >1) & (numeros > 5))
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }

        static void Main(string[] args)
        {
            Password[] arraypassword;
            Boolean[] arrayesfuerte;
            int longitud;
            int longpassword;

            System.Console.WriteLine("Introduce la longitud del array");
            longitud = Convert.ToInt32(Console.ReadLine());
            arraypassword = new Password[longitud];
            arrayesfuerte = new Boolean[longitud];
            System.Console.WriteLine("Introduce la longitud del password");
            longpassword = Convert.ToInt32(Console.ReadLine());
            for (int i =0; i<arraypassword.Length; i++)
            {
                arraypassword[i] = new Password(longpassword);
                arrayesfuerte[i] = arraypassword[i].esFuerte();
                Console.WriteLine("Contraseña1: {0} valor_booleano1 {1}", arraypassword[i].contrasena, arrayesfuerte[i]);
            }


        }
    }
}
