using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConverterIMG
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConverterImagem imagem = new ConverterImagem();
            imagem.ConverterBase64();            
        }

    }
}
