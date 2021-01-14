using System.Collections.Generic;
using System.IO;
using EPlayers_AspNetCore.Interfaces;

namespace EPlayers_AspNetCore.Models
{
    public class Equipe : EPlayersBase , IEquipe
    {
        
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/Equipe.csv";

        public Equipe()
        {
            CreateFolderAndFile(PATH);
        }

        //Criamos um metodo para preparar a linha do CSV
        public string Prepare(Equipe e)
        {
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }

        public void Create(Equipe e)
        {
            //Preparamos um array de string para o metodo AppendAllLines
            string [] linhas = {Prepare(e)};
            //Criamos uma nova linha
            File.AppendAllLines(PATH, linhas);
        }

        public void Delete(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            //removemos a linha com o codigo comparado
            linhas.RemoveAll( x => x.Split(";")[0] == id.ToString() );

            //reescreve o cvs com a lista alterada 
            RewriteCSV(PATH, linhas);
        }

        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();

            //lemos todas as linhas do CSV
            string[] linhas = File.ReadAllLines(PATH);

            foreach(string item in linhas)
            {
                //1;VivoKeyd;Vivo.jpg
                string[] linha = item.Split(";");

                Equipe novaEquipe = new Equipe();
                novaEquipe.IdEquipe = int.Parse( linha[0] );
                novaEquipe.Nome = linha[1];
                novaEquipe.Imagem = linha[2];

                equipes.Add(novaEquipe);
            }

            return equipes;
        }

        public void Update(Equipe e)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            //removemos a linha com o codigo comparado
            linhas.RemoveAll( x => x.Split(";")[0] == e.IdEquipe.ToString() );
            
            //adicionamos na lista a equipe alterada
            linhas.Add( Prepare(e) );

            //reescreve o cvs com a lista alterada 
            RewriteCSV(PATH, linhas);
        }


    }
}