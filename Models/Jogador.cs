using System.Collections.Generic;
using E_Players_AspNETCore.Interfaces;

namespace EPlayers_AspNetCore.Models
{
    public class Jogador : EPlayersBase , IJogador
    {
        
        public int IdJogador { get; set; }
        public string Nome { get; set; }
        public int IdEquipe { get; set; }

        // Login
        public string Email { get; set; }
        public string Senha { get; set; }
        

        // Caminho para armazenar os dados do jogador 
        private const string PATH = "Database/Jogador.csv";

        public Jogador()
        {
            CreateFolderAndFile(PATH);
        }

        public void Create(Jogador j)
        {
            throw new System.NotImplementedException();
        }

        public List<Jogador> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Jogador j)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}