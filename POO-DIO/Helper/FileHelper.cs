﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_DIO.Helper
{
    class FileHelper
    {
        public void ListarDiretorios(string caminho)
        {
            var retornoCaminho = Directory.GetDirectories(caminho, "*", SearchOption.AllDirectories);

            foreach (var retorno in retornoCaminho)
            {
                Console.WriteLine(retorno);
            }

        }

        public void ListarArquivosDiretorios(string caminho)
        {
            //var retornoArquivos = Directory.GetFiles(caminho, "*.txt", SearchOption.AllDirectories); -> buscar arquivos específicos.
            var retornoArquivos = Directory.GetFiles(caminho, "*", SearchOption.AllDirectories);

            foreach (var retorno in retornoArquivos)
            {
                Console.WriteLine(retorno);
            }

        }   

        public void CriarDiretorio(string caminho)
        {
            var retorno = Directory.CreateDirectory(caminho);

            Console.WriteLine(retorno.FullName);

        }

        public void ApagarDiretorio(string caminho, bool apagarArquivos)
        {
            Directory.Delete(caminho, apagarArquivos);
            Console.WriteLine("Deletado com sucesso...");

        }

        public void CriarArquivoTexto(string caminho, string conteudo)
        {
            if (!File.Exists(caminho))
            {
                File.WriteAllText(caminho, conteudo);
            }

        }

        public void CriarArquivoTextoStream(string caminho, List<string> conteudo)
        {
            using ( var stream = File.CreateText(caminho))
            {
                foreach (var linha in conteudo)
                {
                    stream.WriteLine(linha);
                }
            }


        }

        public void AdicionarTexto(string caminho, string conteudo)
        {
            File.AppendAllText(caminho, conteudo);
        }


        public void AdicionarTextoStream(string caminho, List<string> conteudo)
        {
            using (var stream = File.AppendText(caminho))
            {
                foreach (var linha in conteudo)
                {
                    stream.WriteLine(linha);
                }
            }


        }


        public void LerArquivo(string caminho)
        {
            var conteudo = File.ReadAllLines(caminho);

            foreach (var linha in conteudo)
            {
                Console.WriteLine(linha);
            }
        }

        public void LerArquivoStream(string caminho)
        {
            string linha = string.Empty;

            using (var stream = File.OpenText(caminho))
            {
                while ((linha = stream.ReadLine()) != null)
                {
                    Console.WriteLine(linha);
                }
            }
        }

        public void MoverArquivo(string caminho, string novoCaminho)
        {
            File.Move(caminho, novoCaminho);
        }

        public void CopiarArquivo(string caminho, string novoCaminho,bool sobrescrever)
        {
            File.Copy(caminho, novoCaminho, sobrescrever);
        }

        public void DeletarArquivo(string caminho)
        {
            File.Delete(caminho);
        }



    }
}
