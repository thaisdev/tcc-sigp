using System;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IRotaAppService : IDisposable
    {
        void Adicionar(RotaViewModel rotaViewModel);
        void Atualizar(RotaViewModel rotaViewModel);
        void Excluir(int id);
    }
}