//using System;
//using System.Collections.Generic;
//using System.Linq;
//using AutoMapper;
//using Virtus.Core.Application.Interfaces;
//using Virtus.Core.Application.ViewModels;
//using Virtus.Core.Domain.EntitiesSaas;
//using Virtus.Core.Domain.InterfacesSaas.Repository;
//using Virtus.Core.Infra.Data.Interfaces;

//namespace Virtus.Core.Application.Services
//{
//    public class RelatorioDesenpenhoAppService : ApplicationService, IRelatorioDesenpenhoAppService
//    {
//        private readonly IRelatorioDesempenhoRepository _relatorioDesempenhoRepository;
//        public RelatorioDesenpenhoAppService(IUnitOfWork uow, IRelatorioDesempenhoRepository relatorioDesempenhoRepository) : base(uow)
//        {
//            _relatorioDesempenhoRepository = relatorioDesempenhoRepository;
//        } 

//        public void Dispose()
//        {
//            _relatorioDesempenhoRepository.Dispose();
//            GC.SuppressFinalize(this);
//        }

//        public List<RelatorioDesempenhoViewModel> ObterRegistrosDoMesCorrente()
//        {
//            return Mapper.Map<List<RelatorioDesempenho>, List<RelatorioDesempenhoViewModel>>(_relatorioDesempenhoRepository.ObterRegistrosDoMesCorrente());
//        }

//        public DashboardViewModel ObterDadosRelatorioDesenpenho()
//        {
//            var dadosDoMes = Mapper.Map<List<RelatorioDesempenho>, List<RelatorioDesempenhoViewModel>>(_relatorioDesempenhoRepository.ObterRegistrosDoMesCorrente());
//            var dadosPorUsuario = Mapper.Map<List<RelatorioDesempenho>, List<RelatorioDesempenhoViewModel>>(_relatorioDesempenhoRepository.ObterRegistrosUsuarios());
//            var hoje = DateTime.Today;
//            var listaAbertos = new[] { "started", "new" };


//            var dash = new DashboardViewModel
//            {
//                RelatorioDesempenho = dadosDoMes,
//                DadosPorUsuario = dadosPorUsuario,
//                TarefasEmAberto = dadosDoMes.Count(x => listaAbertos.Contains(x.status) && x.deadline > hoje.AddDays(7)),
//                TarefasUrgentes = dadosDoMes.Count(x=>x.deadline < hoje.AddDays(7) && x.deadline >= DateTime.Today && listaAbertos.Contains(x.status)),
//                TarefasVencidas = dadosDoMes.Count(x => x.deadline < hoje && listaAbertos.Contains(x.status)),
//                TotalTarefasFinalizadas = dadosDoMes.Count(x => x.status == "finished"),
//                TarefasFinalizadas = dadosDoMes.Where(x => x.status == "finished").ToList(),
//                TarefasVencidasPorUsuario = dadosDoMes.Where(x=>x.deadline < hoje && listaAbertos.Contains(x.status)).ToList()
//            };
//            return dash;


//        }



//    }
//}