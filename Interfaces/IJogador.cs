using System.Collections.Generic;
using EPlayers_AspNetCore.Models;

namespace E_Players_AspNETCore.Interfaces
{
    public interface IJogador
    {
        
        //CRUD - Contrato metodos que herdarem são obrigados a usar o crud
        //Criar
        void Create(Jogador j);

        //Ler
        List<Jogador> ReadAll();
       
        //Alterar
        void Update(Jogador j);
        
        //Excluir
        void Delete(int id);

    }
}