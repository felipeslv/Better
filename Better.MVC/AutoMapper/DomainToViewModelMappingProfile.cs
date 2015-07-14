using AutoMapper;
using Better.Domain.Entities;
using Better.MVC.ViewModels;

namespace Better.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<EstacionamentoViewModel, Estacionamento>();
            Mapper.CreateMap<TabelaValorViewModel, TabelaValor>();
        }
    }
}