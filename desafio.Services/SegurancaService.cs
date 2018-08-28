using System;
using System.Collections.Generic;
using System.Text;

using System.Security.Cryptography;
using System.IO;

namespace desafio.Services
{
    public static class SegurancaService
    {

        private static byte[] byteIV = { 0x8c, 0xdf, 0x5d, 0x7d, 0x69, 0x4d, 0x3b, 0x23, 0x21, 0xaa, 0x77, 0x2f, 0x8c, 0xf2, 0x63, 0x2b };
        private static  byte[] chave = { 0xae, 0xe2, 0x0a, 0xe3, 0xa3, 0x8e, 0x59, 0xdb, 0xaf, 0xee, 0xcb, 0xc4, 0x52, 0x46, 0xbc, 0x36, 0x79, 0xc1, 0x21, 0x1a, 0x8e, 0xcb, 0x7a, 0xd1, 0xd1, 0xf0, 0x7b, 0x5b, 0x73, 0x22, 0xc8, 0x0a };

        public static string Encriptar(string texto)
        {
            if (texto == null || texto.Length <= 0)
                throw new ArgumentNullException("texto");

            string textoEnciptado;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = chave;
                aesAlg.IV = byteIV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(texto);
                        }
                        textoEnciptado = Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
            return textoEnciptado;
        }
        public static string Desencriptar(string texto)
        { 
            if (texto == null || texto.Length <= 0)
                throw new ArgumentNullException("texto");

            byte[] byteTexto = Convert.FromBase64String(texto);
            string retorno = string.Empty;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = chave;
                aesAlg.IV = byteIV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(byteTexto))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            retorno = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return retorno;
        }
    }
}
