using System.Collections.Generic;
using System.IO;

namespace EPlayers_AspNetCore.Models
{
    public class EPlayersBase
    {
        
        public void CreateFolderAndFile(string _path)
        {
            // DataBase/Equipe
            string folder = _path.Split("/")[0];

            if(!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if(!File.Exists(_path))
            {
                File.Create(_path);
            }
        }


        public List<string> ReadAllLinesCSV(string path)
        {
            List<string> linhas = new List<string>();

            //using é responsavel por abrir e fechar o arquivo automaticamente 
            //StreamReader -> ler dados de um arquivo
            using(StreamReader file = new StreamReader(path))
            {
                string linha;

                //percorrer as linhas com o laço while
                while ((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }

            return linhas;
        }


        public void RewriteCSV(string path, List<string> linhas)
        {
            //StreamWriter -> escrever dados em um arquivo
            using(StreamWriter output = new StreamWriter(path))
            {
                foreach (var item in linhas)
                {
                    output.Write(item + '\n');
                }
            }
        }



    }
}